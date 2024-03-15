using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    void Start(){
        pauseMenu.GoToMainMenu();
    }
}
