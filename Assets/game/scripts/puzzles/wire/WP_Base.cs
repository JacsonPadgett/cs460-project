using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WP_Base : MonoBehaviour
{
    public XRSocketInteractor XRSI;
    public GameObject attached;
    //Whole Puzzle ID
    public int puzzle_id;
    //Individual BP ID
    public int BP_id;
    //Correct Piece Type
    public int correct_piece_id;
    //Correct Piece Rotation
    public int correct_subpiece_id;
    [HideInInspector]
    public bool isCorrect = false;

    public GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkPiece()
    {
        if (XRSI.hasSelection)
        {
            Debug.Log("Has attached piece");
            attached = XRSI.selectTarget.gameObject;
        }

        if(attached != null && correct_piece_id == attached.GetComponent<WP_Piece>().id && correct_subpiece_id == attached.GetComponent<WP_Piece>().sub_id)
        {
            isCorrect = true;
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
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
        WP_Manager.checkSolution(puzzle_id);
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
        WP_Manager.checkSolution(puzzle_id);
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
