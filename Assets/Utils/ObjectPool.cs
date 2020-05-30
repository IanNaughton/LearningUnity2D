using System;
using System.Collections;
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
  #endregion

  public static ObjectPool Instance;

  // This feels kind of dumb--we're relying on some framework magic here
  // that I would argue makes this implementation brittle.
  private void Awake() {
    Instance = this;
  }
  public Dictionary<string, Queue<GameObject>> PooledObjects;

  void Start()
  {
    foreach (var pool in ObjectsToPool)
    {
      var objectPool = new Queue<GameObject>();
      for (int i = 0; i < pool.NumberToPool; i++)
      {
          var objectToPool = Instantiate(pool.ObjectToPool);
          objectToPool.SetActive(false);
          objectPool.Enqueue(pool.ObjectToPool);
      }
      PooledObjects.Add(pool.Key, objectPool);
    }
  }

  public GameObject SpawnObject(string tag, Vector2 position, Quaternion rotation)
  {
    var objectToSpawn = PooledObjects[tag].Dequeue();
    objectToSpawn.SetActive(true);
    objectToSpawn.transform.position = position;
    objectToSpawn.transform.rotation = rotation;
    

    PooledObjects[tag].Enqueue(objectToSpawn);
    return objectToSpawn;
  }

  public void RemoveObject(string tag, GameObject objectToPool)
  {
    PooledObjects[tag].Enqueue(objectToPool);
  }
}