using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Board : MonoBehaviour
{
    public GameObject cardPrefab;

    private List<GameObject> cardList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            GameObject go = Instantiate(cardPrefab, transform);
            go.GetComponent<Card>().Setting(arr[i]);

            cardList.Add(go);
        }

        if (GameManager.Instance == null)
        {
            Debug.Log("is null");
        }


        GameManager.Instance.cardCount = arr.Length;

        for (int i = 0; i < cardList.Count; i++)
        {

            float x = i % 4 * 1.4f - 2.1f;
            float y = i / 4 * 1.4f - 3.0f;

            cardList[i].transform.DOMove(new Vector2(x, y), 0.5f);
        }
    }
}
