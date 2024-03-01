using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerObject;



    public void Level1(){
        // Set the player's position after loading the scene
        
        Vector3 postion = new Vector3(0, 2, 0);
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
