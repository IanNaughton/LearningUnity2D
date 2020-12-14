using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int CratesCollected;

    public void CrateCollected()
    {
        CratesCollected += 1;
    }
}
