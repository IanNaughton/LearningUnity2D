using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroEnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public int secondsBeforeSpawn;
    public float speedMultiplier;
    public GameObject aggroEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QueueAggroEnemy(GameObject enemy)
    {
        var enemySpeed = enemy.GetComponent<Enemy>().Speed;
        // A decision would be made here as to what type of 
        // enemy needs to spawn.
        StartCoroutine(SpawnAggroEnemy(enemySpeed));
    }

    public IEnumerator SpawnAggroEnemy(float enemySpeed)
    {
        yield return new WaitForSeconds(secondsBeforeSpawn);

        var aggroEnemyInstance = Instantiate(aggroEnemy, spawnPoint.position, spawnPoint.rotation);
        var enemy = aggroEnemyInstance.GetComponent<Enemy>();
        enemy.Speed = enemySpeed * speedMultiplier;
    }
}
