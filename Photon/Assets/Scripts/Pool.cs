using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    private static Transform spawnPool;

    private List<GameObject> objects;
    private GameObject prefab;

    public Pool(GameObject sample, int startSize = 0)
    {
        if(spawnPool == null)
            spawnPool = new GameObject("Pool").transform;
        objects = new List<GameObject>();
        prefab = sample;
        for (int i = 0; i < startSize; i++)
        {
            objects.Add(Instantiate(prefab));
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].activeSelf)
                return objects[i];
        }
        objects.Add(Instantiate(prefab, spawnPool));
        return objects[objects.Count - 1];
    }

}
