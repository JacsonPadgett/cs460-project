using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WP_Base : MonoBehaviour
{
    public XRSocketInteractor XRSI;
    private GameObject attached;
    public int puzzle_id;
    public int correct_piece_id;
    public int correct_subpiece_id;
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

    public void checkPiece()
    {
        if (XRSI.hasSelection)
        {
            attached = XRSI.selectTarget.gameObject;
        }
        if(attached != null && correct_piece_id == attached.GetComponent<WP_Piece>().id && correct_subpiece_id == attached.GetComponent<WP_Piece>().sub_id)
        {
            isCorrect = true;
            Debug.Log("Correct Piece Set");
        }
        else
        {
            isCorrect= false;
            Debug.Log("Incorrect Piece Set / Incorrect Rotation / No Piece Set");
        }
        WP_Manager.checkSolution(puzzle_id);
    }

    public void removePiece()
    {
        attached.GetComponent<WP_Piece>().resetRotation();
        attached = null;
        isCorrect = false;
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
