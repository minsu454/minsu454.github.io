using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject rain;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(MakeRain), 0f, 1f);
    }

    private void MakeRain()
    {
        Instantiate(rain);
    }
}
