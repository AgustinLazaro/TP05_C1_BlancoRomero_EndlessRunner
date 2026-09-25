using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialPoolSize = 5;

    private Queue<GameObject> poolQueue;

    private void Awake()
    {
        poolQueue = new Queue<GameObject>();
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = CreateNewInstance();
            poolQueue.Enqueue(obj); 
        }
    }

    private GameObject CreateNewInstance()
    {
        GameObject newObject = Instantiate(prefab, transform);
        newObject.SetActive(false);
        return newObject; 
    }

    public GameObject Get(Vector3 position)
    {
        GameObject objectSpawn;

        if (poolQueue.Count > 0)
        {
            objectSpawn = poolQueue.Dequeue();
        }
        else
        {
            objectSpawn = CreateNewInstance(); 
        }

        objectSpawn.transform.position = position;
        objectSpawn.SetActive(true);
        return objectSpawn;
    }

    public void ReturnToPool(GameObject objectReturn)
    {
        objectReturn.SetActive(false);
        poolQueue.Enqueue(objectReturn);
    }
}