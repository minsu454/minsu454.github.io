using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using System.Runtime.CompilerServices;

public class Board : MonoBehaviour
{
    public GameObject cardPrefab;

    private List<GameObject> cardList = new List<GameObject>();

    public int cardCount = 0;

    void Start()
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
            go.GetComponent<Card>().Setting(list[i]);

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
                    x = 0;
                    y = 0;
                    break;
            }
            cardList[i].transform.DOMove(new Vector2(x, y), 0.7f).OnComplete(() => { TimeManager.Instance.isStart = true; });

        }
    }

    public void SetCardCount(int cardCount)
    {
        this.cardCount = cardCount;
    }
}
