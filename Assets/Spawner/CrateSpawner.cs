using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public GameObject CratePrefab;
    public GameState GameState;
    private GameObject SpawnedCrate;
    private int previousSpawn; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnedCrate == null)
        {
            SpawnCrate();
        }
    }

    void SpawnCrate()
    {
        var spawn = GetNextSpawnPoint();
        var selectedSpawn = SpawnPoints[spawn];
        SpawnedCrate = Instantiate(CratePrefab, selectedSpawn.transform.position, selectedSpawn.transform.rotation);
        
        // This is a stupid hack
        // TODO: DO THIS IN A WAY THAT ISN'T SUPER DUMB
        // This is the only way I was able to save the 
        // crate as a prefab AND hold a reference to the 
        // game state object. What this SHOULD be is a script 
        // that broadcasts a message that the game state
        // subscribes to.
        var crateComponent = SpawnedCrate.GetComponent<Crate>();
        crateComponent.gameState = GameState;
    }

    /// <summary>
    /// When a crate is spawned, it should not use
    /// the same spawn twice back-to-back
    /// </summary>
    private int GetNextSpawnPoint()
    {
        var nextSpawn = 0;
        while (nextSpawn == previousSpawn)
        {
            nextSpawn = Random.Range(0, SpawnPoints.Count - 1);
        }
        previousSpawn = nextSpawn;
        return nextSpawn;
    }
}
