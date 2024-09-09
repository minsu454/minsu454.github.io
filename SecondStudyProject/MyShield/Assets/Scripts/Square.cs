using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3f, 5f);

        transform.position = new Vector2(x, y);

        float size = Random.Range(0.5f, 1.5f);

        transform.localScale = new Vector2(size, size);
    }
}