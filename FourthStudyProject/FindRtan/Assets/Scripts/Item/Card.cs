using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int idx = 0;            //��ī�� �ε��� ����
    public int Index                //idx getter
    {
        get { return idx; }
    }

    public GameObject front;            //ī�� �ո� obj
    public SpriteRenderer frontImage;   //ī�� �ո� �̹���

    public GameObject back;             //ī�� �޸� obj

    public Animator anim;               //ī�� anim

    /// <summary>
    /// ī�� idx������ �������ִ� �Լ�
    /// </summary>
    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Cards/Card{idx}");
    }

    /// <summary>
    /// ī�� spriteNum ������ �������ִ� �Լ�
    /// </summary>
    public void Setting(int number, int spriteNum)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Cards/Card{spriteNum}");
    }

    /// <summary>
    /// ī�� �����ϴ� �Լ�
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
    /// �ִϸ��̼� �������ִ� �Լ�
    /// </summary>
    public void StartAnim()
    {
        anim.SetBool("isOpen", true);
    }

    /// <summary>
    /// Invoke�� �̿��� ī�� �ı��Ǵ� �Լ�
    /// </summary>
    public void DestoryCard()
    {
        GameManager.Instance.board.RemoveCardGo(gameObject);
        Invoke(nameof(DestoryCardInvoke), 0.3f);
    }

    /// <summary>
    /// ī�� �ı��ϴ� �Լ�
    /// </summary>
    private void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Invoke�� �̿��� ī�� �����ִ� �Լ�
    /// </summary>
    public void CloseCard(bool isIvoke = true)
    {
        if (isIvoke)
            Invoke(nameof(CloseCardInvoke), 0.3f);
        else
            CloseCardInvoke();
    }

    /// <summary>
    /// ī�� �����ִ� �Լ�
    /// </summary>
    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
