using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerObject;

    void Start()
    {
        // Set playerObject to the GameObject with the "Player" tag
        playerObject = GameObject.FindWithTag("PlayerObject");

        // Check if playerObject is null (no GameObject with the "Player" tag found)
        if (playerObject == null)
        {
            Debug.LogError("Player object not found in the scene!");
        }
    }

    public void Level1(){
        // Set the player's position after loading the scene
        
        Vector3 postion = new Vector3(0, 2, 0);
        FindObjectOfType<SceneController>().SwitchScene("Level1", postion);
    }
    public void Level2()
    {
        // Set the player's position after loading the scene
        
        Vector3 postion = new Vector3(-16f,2f,24f);
        FindObjectOfType<SceneController>().SwitchScene("Level2", postion);

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
