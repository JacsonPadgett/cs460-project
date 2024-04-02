using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WP_Base : MonoBehaviour
{
    public XRSocketInteractor XRSI;
    public GameObject attached;
    //Correct Piece Type
    public int correct_type;
    //Correct Piece Rotation
    public int correct_rotation;
    [HideInInspector]
    public bool isCorrect = false;

    public GameObject[] lights;

    public WP_Manager_New puzzleManager;

    public void checkPiece()
    {
        if (XRSI.hasSelection)
        {
            Debug.Log("Has attached piece");
            attached = XRSI.selectTarget.gameObject;
        }

        if(attached != null && correct_type == attached.GetComponent<WP_Piece>().type && correct_rotation == attached.GetComponent<WP_Piece>().rotation)
        {            
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
            
            isCorrect = true;
            puzzleManager.checkSolution();

            Debug.Log("Correct Piece Set");
        }
        else
        {
            isCorrect= false;
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
            Debug.Log("Incorrect Piece Set / Incorrect Rotation / No Piece Set");
        }
        puzzleManager.checkSolution();
    }

    public void removePiece()
    {
        attached.GetComponent<WP_Piece>().resetRotation();
        attached = null;
        isCorrect = false;

        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }

        Debug.Log("Piece has been removed");
    }

    public void rotatePiece()
    {
        if(attached != null)
        {
            Debug.Log("There is a piece to rotate!");
            attached.GetComponent<WP_Piece>().ObjRotation();
        }
    }
}
