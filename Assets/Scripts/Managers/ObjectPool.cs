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
        int count = 0;

        while (count < initialPoolSize)
        {
            CreateNewInstance();
            count++;
        }
    }

    private GameObject CreateNewInstance()
    {
        GameObject newObject = Instantiate(prefab, transform);
        newObject.SetActive(false);
        poolQueue.Enqueue(newObject);
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
