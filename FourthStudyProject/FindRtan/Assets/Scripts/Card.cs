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

    private AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;
        if (GameManager.Instance.firstCard == this) return;

        audioSource.PlayOneShot(clip);

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
        Invoke(nameof(DestoryCardInvoke), 0.5f);
    }

    public void DestoryCardInvoke()
    {
        Destroy(gameObject);
        
    }

    public void CloseCard()
    {
        Invoke(nameof(CloseCardInvoke), 0.5f);
    }

    public void CloseCardInvoke()
    {
        
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
