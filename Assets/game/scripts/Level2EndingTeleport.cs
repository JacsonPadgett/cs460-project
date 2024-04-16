using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EndingTeleport : MonoBehaviour
{
    private PauseMenu pauseMenu;

    void Start(){
        GameObject gameManagerObject = GameObject.FindWithTag("Player");

        if (gameManagerObject != null)
        {
            pauseMenu = gameManagerObject.GetComponent<PauseMenu>();
        }
    }
    void OnTriggerEnter(){
        pauseMenu.GoToMainMenu();
    }
}