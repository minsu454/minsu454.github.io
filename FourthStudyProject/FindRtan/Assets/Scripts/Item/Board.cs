using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using System.Runtime.CompilerServices;
using DG.Tweening.Core.Easing;

public class Board : MonoBehaviour
{
    public GameObject cardPrefab;

    private List<GameObject> cardList = new List<GameObject>();

    public int cardCount = 0;

    public void StartGame(BossType type = BossType.None)
    {
        if (cardCount % 2 != 0) return;

        List<int> list = new List<int>();

        for (int i = 0; i < cardCount / 2; i++)
        {
            list.Add(i);
            list.Add(i);
        }

        list = list.OrderBy(x => Random.Range(0f, 7f)).ToList();

        for (int i = 0; i < list.Count; i++)
        {
            GameObject go = Instantiate(cardPrefab, transform);

            switch (type)
            {
                case BossType.Same:
                    go.GetComponent<Card>().Setting(list[i], 0);
                    break;
                case BossType.ImageError:
                    go.GetComponent<Card>().Setting(list[i], Random.Range(0, cardCount / 2));
                    break;
                default:
                    go.GetComponent<Card>().Setting(list[i]);
                break;
            }
            
            cardList.Add(go);
        }

        MoveCard();
    }

    private void MoveCard()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            float x;
            float y;

            switch (cardCount)
            {
                case 4:
                    x = i % 2 * 1.4f - 0.7f;
                    y = i / 2 * 1.4f - 1.6f;
                    break;
                case 8:
                    x = i % 4 * 1.4f - 2.1f;
                    y = i / 4 * 1.4f - 1.6f;
                    break;
                case 12:
                    x = i % 4 * 1.4f - 2.1f;
                    y = i / 4 * 1.4f - 2.25f;
                    break;
                case 16:
                    x = i % 4 * 1.4f - 2.1f;
                    y = i / 4 * 1.4f - 3.0f;
                    break;
                case 24:
                    x = i % 4 * 1.4f - 2.1f;
                    y = i / 4 * 1.4f - 4.2f;
                    break;
                default:
                    x = i % 4 * 1.4f - 2.1f;
                    y = i / 4 * 1.4f - 3.0f;
                    break;
            }
            cardList[i].transform.DOMove(new Vector2(x, y), 0.7f).OnComplete(() => { TimeManager.Instance.isStart = true; });

        }
    }

    public void ShuffleCard()
    {
        StartCoroutine(CoShuffleCard());
    }

    IEnumerator CoShuffleCard()
    {
        if (GameManager.Instance.firstCard != null)
        {
            GameManager.Instance.firstCard.CloseCard(false);
            GameManager.Instance.firstCard = null;
        }

        for (int i = 0; i < cardList.Count; i++)
        {
            cardList[i].transform.DOMove(new Vector2(2, 4), 0.7f);
        }

        cardList = cardList.OrderBy(x => Random.Range(0f, 7f)).ToList();

        yield return new WaitForSeconds(0.8f);

        MoveCard();

        StopCoroutine(CoShuffleCard());
    }

    public void SetCardCount(int cardCount)
    {
        this.cardCount = cardCount;
    }

    internal void RemoveCardGo(GameObject card)
    {
        cardList.Remove(card);
    }
}
