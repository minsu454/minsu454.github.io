using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private string playerTag;

    public Transform Player { get; private set; }
    public ObjectPool ObjectPool { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);

        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Destroy(Instance);
    }
}
