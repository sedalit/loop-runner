using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private int count;
    [SerializeField] private float minSecondsBetweenSpawn = 0.4f;
    [SerializeField] protected float secondsBetweenSpawn;
    private List<GameObject> pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newObject = Instantiate(prefab, container.transform);
            newObject.SetActive(false);
            pool.Add(newObject);
        }
    }

    protected bool TryGetObject<T>(out T result) where T : MonoBehaviour
    {
        //result = pool.FirstOrDefault(p => p.activeSelf == false);
        result = pool[Random.Range(0, pool.Count)].GetComponent<T>();
        return result != null && result.gameObject.activeSelf == false;
    }

    protected void SetObject<T>(T currentObject, Vector3 spawnPoint) where T : MonoBehaviour
    {
        currentObject.gameObject.SetActive(true);
        currentObject.transform.position = spawnPoint;
    }

    protected virtual void OnDistanceFactorUpdated()
    {
        if (secondsBetweenSpawn <= minSecondsBetweenSpawn) return;
        secondsBetweenSpawn -= 0.25f;
    }
}
