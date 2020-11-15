using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region "UI Stuff"

    // This object appears as a form to
    [Serializable]
    public class PooledObject
    {
        public GameObject ObjectToPool;
        public int NumberToPool;
        public string Key;
    }

    public List<PooledObject> ObjectsToPool;

    #endregion "UI Stuff"

    public static ObjectPool Instance;

    // This feels kind of dumb--we're relying on some framework magic here
    // that I would argue makes this implementation brittle.
    private void Awake()
    {
        Debug.Log("Waking Up!");
        Instance = this;
        Debug.Log("Woke AF");
    }

    public Dictionary<string, Queue<GameObject>> PooledObjects;

    private void Start()
    {
        var tempPool = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in ObjectsToPool)
        {
            var objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.NumberToPool; i++)
            {
                var objectToPool = Instantiate(pool.ObjectToPool);
                objectToPool.SetActive(false);
                objectPool.Enqueue(objectToPool);
            }
            tempPool.Add(pool.Key, objectPool);
        }
        PooledObjects = tempPool;
    }

    public GameObject SpawnObject(string tag, Vector2 position, Quaternion rotation)
    {
        Debug.Log($"Spawning Object with tag {tag}");
        var objectToSpawn = PooledObjects[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        Debug.Log($"Spawned object {objectToSpawn.name}");

        PooledObjects[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public void RemoveObject(string tag, GameObject objectToPool)
    {
        objectToPool.SetActive(false);
        PooledObjects[tag].Enqueue(objectToPool);
    }
}