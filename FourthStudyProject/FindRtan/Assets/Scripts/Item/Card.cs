using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Cards/Card{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;
        if (GameManager.Instance.firstCard == this) return;

        SoundManager.Instance.PlaySFX(SfxType.Flip);

        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }

    public void StartAnim()
    {
        anim.SetBool("isOpen", true);
    }

    public void DestoryCard()
    {
        GameManager.Instance.board.RemoveCardGo(gameObject);
        Invoke(nameof(DestoryCardInvoke), 0.3f);
    }

    public void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard(bool isIvoke = true)
    {
        if (isIvoke)
            Invoke(nameof(CloseCardInvoke), 0.3f);
        else
            CloseCardInvoke();
    }

    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
