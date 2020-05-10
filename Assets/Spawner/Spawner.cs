using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public GameObject ThingToSpawn;
  public float WaveDuration;
  public int NumberOfInstances;
  public float TimeBetweenInstance;
  void Start()
  {
    StartCoroutine(SpawnWave());
  }
  void Update()
  {

  }

  public IEnumerator SpawnWave()
  {
    while (true)
    {
      for (int i = 0; i < NumberOfInstances; i++)
      {
        Instantiate(ThingToSpawn, transform.position, transform.rotation);
        yield return new WaitForSeconds(TimeBetweenInstance);
      }
      yield return new WaitForSeconds(WaveDuration);
    }
  }
}

