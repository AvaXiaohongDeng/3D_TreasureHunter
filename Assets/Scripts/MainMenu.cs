using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadTreasureTerrain()
    {
        Debug.Log("Treasure Terrain Scene Loading");
        SceneManager.LoadScene("TreasureTerrain");
    }

    public void ExitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }
}
