using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public GameObject ThingToSpawn;
  public float WaveDuration;
  public int NumberOfInstances;
  public float TimeBetweenInstance;
  public SpawnerDirection WaveDirection;
  void Start()
  {
    StartCoroutine(SpawnWave());
  }
  void Update()
  {

  }

  public IEnumerator SpawnWave()
  {
    // Infinitely loop creating waves
    while (true)
    {
      // Spawn the individual entities that make up a wave
      for (int i = 0; i < NumberOfInstances; i++)
      {
        var instance = Instantiate(ThingToSpawn, transform.position, transform.rotation);
        var enemy = instance.GetComponent<Enemy>();
        enemy.Speed = GetSpeed(enemy.Speed);
        yield return new WaitForSeconds(TimeBetweenInstance);
      }
      WaveDirection = WaveDirection == SpawnerDirection.Right ? SpawnerDirection.Left : SpawnerDirection.Right;
      yield return new WaitForSeconds(WaveDuration);
    }
  }

  public float GetSpeed(float speed)
  {
    return WaveDirection == SpawnerDirection.Left ? speed * -1 : speed;
  }
}

