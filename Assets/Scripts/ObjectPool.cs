using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private List<GameObject> objectList;

    [SerializeField] private int poolSize;

    public static ObjectPool Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    void Start()
    {
        AddObjectsToPool(poolSize);
    }

    private void AddObjectsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            objectList.Add(obj);
            obj.transform.parent = transform;
        }
    }

    public GameObject RequestObject()
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            if (!objectList[i].activeSelf)
            {
                objectList[i].SetActive(true);
                return objectList[i];
            }
        }
        AddObjectsToPool(1);
        objectList[objectList.Count - 1].SetActive(true);
        return objectList[objectList.Count - 1];


    }

    void Update()
    {
        
    }
}
