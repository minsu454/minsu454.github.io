using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int idx = 0;            //내카드 인덱스 변수
    public int Index                //idx getter
    {
        get { return idx; }
    }

    public GameObject front;            //카드 앞면 obj
    public SpriteRenderer frontImage;   //카드 앞면 이미지

    public GameObject back;             //카드 뒷면 obj

    public Animator anim;               //카드 anim

    /// <summary>
    /// 카드 idx값으로 설정해주는 함수
    /// </summary>
    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Cards/Card{idx}");
    }

    /// <summary>
    /// 카드 spriteNum 값으로 설정해주는 함수
    /// </summary>
    public void Setting(int number, int spriteNum)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Cards/Card{spriteNum}");
    }

    /// <summary>
    /// 카드 오픈하는 함수
    /// </summary>
    public void OpenCard()
    {
        if (GameManager.Instance.board.secondCard != null) return;
        if (GameManager.Instance.board.firstCard == this) return;

        SoundManager.Instance.PlaySFX(SfxType.Flip);

        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.board.firstCard == null)
        {
            GameManager.Instance.board.firstCard = this;
        }
        else
        {
            GameManager.Instance.board.secondCard = this;
            GameManager.Instance.board.Matched();
        }
    }

    /// <summary>
    /// 애니메이션 설정해주는 함수
    /// </summary>
    public void StartAnim()
    {
        anim.SetBool("isOpen", true);
    }

    /// <summary>
    /// Invoke를 이용해 카드 파괴되는 함수
    /// </summary>
    public void DestoryCard()
    {
        GameManager.Instance.board.RemoveCardGo(gameObject);
        Invoke(nameof(DestoryCardInvoke), 0.3f);
    }

    /// <summary>
    /// 카드 파괴하는 함수
    /// </summary>
    private void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Invoke를 이용해 카드 덮어주는 함수
    /// </summary>
    public void CloseCard(bool isIvoke = true)
    {
        if (isIvoke)
            Invoke(nameof(CloseCardInvoke), 0.3f);
        else
            CloseCardInvoke();
    }

    /// <summary>
    /// 카드 덮어주는 함수
    /// </summary>
    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
