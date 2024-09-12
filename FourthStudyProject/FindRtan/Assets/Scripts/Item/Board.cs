using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using System.Runtime.CompilerServices;
using DG.Tweening.Core.Easing;

public class Board : MonoBehaviour
{
    public GameObject cardPrefab;                                   //카드 프리팹

    private List<GameObject> cardList = new List<GameObject>();     //게임중 쓰이는 카드들 모아놓는 List

    public int cardCount = 0;                                       //남은 카드 적어주는 함수

    [Header("Card")]
    public Card firstCard;                                          //첫번째 뒤집은 카드 저장하는 변수
    public Card secondCard;                                         //두번째 뒤집은 카드 저장하는 변수

    /// <summary>
    /// 게임설정해주고 시작해주는 함수
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
    /// 카드 정렬되는 함수
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
    /// 카드 위치 계산하고 반환해주는 함수
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
    /// 카드 셔플하는 함수
    /// </summary>
    public void ShuffleCard()
    {
        StartCoroutine(CoShuffleCard());
    }

    /// <summary>
    /// 카드 셔플하는 코루틴
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
    /// 뒤집은 카드 비교해주는 함수
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
    /// 카드 list에서 지워주는 함수
    /// </summary>
    internal void RemoveCardGo(GameObject card)
    {
        cardList.Remove(card);
    }
}
