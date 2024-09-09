using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject square;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(MakeSquare), 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeSquare()
    {
        Instantiate(square);
    }
}
