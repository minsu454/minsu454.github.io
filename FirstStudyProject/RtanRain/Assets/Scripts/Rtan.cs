using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    private float direction = 0.05f;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        if (transform.position.x > 2.6f || transform.position.x < -2.6f)
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        transform.position += Vector3.right * direction;
    }
}
