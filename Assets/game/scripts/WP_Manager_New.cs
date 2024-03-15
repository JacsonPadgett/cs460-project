using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WP_Manager_New : MonoBehaviour
{

    public XRSimpleInteractable[] buttons;
    public GameObject key;
    public Light completionLight;
    public Light nextRoomLight;
    public WP_Base[] basePieces;
    
    //Final Puzzle Variables
    public bool finalPuzzle;
    public GameObject secretWall;
    public GameObject[] endingLights;

    public GameObject finalPiece;
    public SubtitleController subtitleController;
    public string phrase;
    public bool phraseComplete = false;

    void Start(){
        Time.timeScale = 1;
        subtitleController = GameObject.FindGameObjectsWithTag("SubtitleObject")[0].GetComponent<SubtitleController>();
    }

    public void checkSolution(){
        //Return if any 1 piece is incorrect
        foreach(WP_Base bp in basePieces){
            if(!bp.isCorrect){
                foreach(XRSimpleInteractable button in buttons){
                    button.enabled = true;
                }

                return;
            }
        }

        //Puzzle Completetion
        //Disable buttons and piece interactability
        foreach(XRSimpleInteractable button in buttons){
            button.enabled = false;
        }

        if(finalPuzzle){
            secretWall.SetActive(false);

            foreach(GameObject light in endingLights){
                light.SetActive(true);
            }

        }
        else{
            key.SetActive(true);
            finalPiece.SetActive(true);
            completionLight.color = Color.green;
            nextRoomLight.color = Color.yellow;
        }

        if(!phraseComplete){
            phraseComplete = true;
            displaySubtitle();
        }
    }

    public void displaySubtitle(){
        subtitleController.startTypeWriter(phrase);
    }
}
