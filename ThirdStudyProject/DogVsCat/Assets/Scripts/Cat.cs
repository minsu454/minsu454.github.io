using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject hungryCat;
    public GameObject fullCat;

    public RectTransform front;

    private float full = 5f;
    private float energy = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        float x = Random.Range(-9f, 9f);
        float y = 30f;
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            transform.position += Vector3.down * 0.05f;
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1f, 1f);
                Destroy(col.gameObject);

                if (energy == 5f)
                {
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);
                }
            }
        }
    }
}
