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
        
        Vector3 postion = new Vector3(-0.0242893547f,1f,-3.40272021f);
        FindObjectOfType<SceneController>().SwitchScene("DemoScene", postion);
    }
    public void Level2()
    {
        // Set the player's position after loading the scene
        
        Vector3 postion = new Vector3(0, 2, 0);
        FindObjectOfType<SceneController>().SwitchScene("Testing Scene", postion);

    }


    public void QuitGame()
    {
        Application.Quit();
    }


  
}
