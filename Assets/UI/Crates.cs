using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crates : MonoBehaviour
{
    public GameState gameState;
    public Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText.text = $"Crates: {gameState.CratesCollected}";
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = $"Crates: {gameState.CratesCollected}";
    }
}
