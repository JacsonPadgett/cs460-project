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
    public AudioManager audioManager;
    public string phrase;
    public AudioClip phraseAudio;
    public bool phraseComplete = false;

    void Start(){
        audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManager>();
        if(audioManager == null){
            Debug.Log("Audio Manager not found...");
        }
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

        //If the final puzzle of level 1, activate ending, else lock room puzzle
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

    //play subitle via audio manager
    public void displaySubtitle(){
        audioManager.PlaySFX(phraseAudio, phrase);
    }
}
