using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void LoadTreasureTerrain()
    {
        Debug.Log("Treasure Terrain Scene Loading");
        SceneManager.LoadScene("TreasureTerrain");
    }

    public void LoadMainMenu()
    {
        Debug.Log("Treasure Terrain Scene Loading");
        SceneManager.LoadScene("MainMenu");
    }
}
