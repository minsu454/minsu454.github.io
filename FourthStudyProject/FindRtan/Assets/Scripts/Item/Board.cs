using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using System.Runtime.CompilerServices;
using DG.Tweening.Core.Easing;

public class Board : MonoBehaviour
{
    public GameObject cardPrefab;                                   //ī�� ������

    private List<GameObject> cardList = new List<GameObject>();     //������ ���̴� ī��� ��Ƴ��� List

    public int cardCount = 0;                                       //���� ī�� �����ִ� �Լ�

    [Header("Card")]
    public Card firstCard;                                          //ù��° ������ ī�� �����ϴ� ����
    public Card secondCard;                                         //�ι�° ������ ī�� �����ϴ� ����

    /// <summary>
    /// ���Ӽ������ְ� �������ִ� �Լ�
    /// </summary>
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

    /// <summary>
    /// ī�� ���ĵǴ� �Լ�
    /// </summary>
    private void MoveCard()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            Vector3 vec;

            switch (cardCount)
            {
                case 4:
                    vec = CardVec(i, 2, -0.7f, -1.6f);
                    break;
                case 8:
                    vec = CardVec(i, 4, -2.1f, -1.6f);
                    break;
                case 12:
                    vec = CardVec(i, 4, -2.1f, -2.25f);
                    break;
                case 24:
                    vec = CardVec(i, 4, -2.1f, -4.2f);
                    break;
                default:
                    vec = CardVec(i, 4, -2.1f, -3f);
                    break;
            }
            cardList[i].transform.DOMove(vec, 0.7f).OnComplete(() => { TimeManager.Instance.isStart = true; });
        }
    }

    /// <summary>
    /// ī�� ��ġ ����ϰ� ��ȯ���ִ� �Լ�
    /// </summary>
    private Vector2 CardVec(int num, int divided, float moveX, float moveY)
    {
        float x;
        float y;

        x = num % divided * 1.4f + moveX;
        y = num / divided * 1.4f + moveY;

        return new Vector2(x, y);
    }

    /// <summary>
    /// ī�� �����ϴ� �Լ�
    /// </summary>
    public void ShuffleCard()
    {
        StartCoroutine(CoShuffleCard());
    }

    /// <summary>
    /// ī�� �����ϴ� �ڷ�ƾ
    /// </summary>
    private IEnumerator CoShuffleCard()
    {
        if (firstCard != null)
        {
            firstCard.CloseCard(false);
            firstCard = null;
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

    /// <summary>
    /// ������ ī�� �����ִ� �Լ�
    /// </summary>
    public void Matched()
    {
        if (firstCard.Index == secondCard.Index)
        {
            SoundManager.Instance.PlaySFX(SfxType.Match);

            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                GameManager.Instance.GameClear();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    /// <summary>
    /// ī�� list���� �����ִ� �Լ�
    /// </summary>
    internal void RemoveCardGo(GameObject card)
    {
        cardList.Remove(card);
    }
}
