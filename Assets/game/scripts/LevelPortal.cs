using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : MonoBehaviour
{
    public int levelID;
    public MainMenu mainMenu;


    void OnTriggerEnter(){
        switch(levelID){
            case 1:
                mainMenu.Level1();
                break;
            case 2:
                mainMenu.Level2();
                break;
            default:
                Debug.Log("Invalid Level ID...");
                break;
        }
    }
}
