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
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (SpawnedCrate == null)
        {
            SpawnCrate();
        }
    }

    private void SpawnCrate()
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
        // subscribes to. But I couldn't figure out a way to 
        // make it work BECAUSE I'M *SOOOOOO* DUMB.
        var crateComponent = SpawnedCrate.GetComponent<Crate>();
        crateComponent.gameState = GameState;
    }

    /// <summary>
    /// Finds a new spawn point without using the same
    /// spawn two consecutive times.
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