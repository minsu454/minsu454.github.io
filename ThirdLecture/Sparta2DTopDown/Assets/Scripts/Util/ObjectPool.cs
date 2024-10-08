using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDic = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        PoolDic = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            PoolDic.Add(pool.tag, queue);
        }

    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!PoolDic.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = PoolDic[tag].Dequeue();
        PoolDic[tag].Enqueue(obj);

        obj.SetActive(true);
        return obj;
    }
}