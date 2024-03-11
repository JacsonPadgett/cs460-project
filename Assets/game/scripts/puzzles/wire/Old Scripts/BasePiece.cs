using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BasePiece : MonoBehaviour
{

    public XRSocketInteractor snapZone;
    private GameObject attachedPiece;
    public int id;

    [HideInInspector]
    public bool isCorrect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void checkPiece(){
        if(snapZone.hasSelection){
            attachedPiece = snapZone.selectTarget.gameObject;
            attachedPiece.GetComponent<InteractablePiece>().updateRotation();
    

            if(id == attachedPiece.GetComponent<InteractablePiece>().id){
                isCorrect = true;
                Debug.Log("correct");
                WirePuzzleManager.instance.checkPuzzle();
            }
            else{
                isCorrect = false;
                Debug.Log("incorrect");
            }
        }
    }

    public void removePiece(){
        attachedPiece.GetComponent<InteractablePiece>().resetRotation();
    }
}
