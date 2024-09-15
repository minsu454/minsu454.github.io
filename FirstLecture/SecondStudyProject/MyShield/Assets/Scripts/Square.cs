using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public float deleteKey = -6f;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3f, 5f);

        transform.position = new Vector2(x, y);

        float size = Random.Range(0.5f, 1.5f);

        transform.localScale = new Vector2(size, size);
    }

    private void Update()
    {
        if (transform.position.y < deleteKey)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
