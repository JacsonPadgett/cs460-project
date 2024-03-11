using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleManager : MonoBehaviour
{
    public static WirePuzzleManager instance;
    public BasePiece[] basePieces;

    //private bool isSolved = false;

    public GameObject[] solutionMechanic;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this){
            Destroy(this);
        }
        else{
            instance = this;
            basePieces = FindObjectsOfType<BasePiece>();
            
            foreach(GameObject g in solutionMechanic){
                g.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void checkPuzzle(){
        bool flag = true;
        while(flag){
            foreach (BasePiece piece in basePieces)
            {
                if(!piece.isCorrect)
                    return;
            }

            //isSolved = true;
            flag = false;
            activateSolution();
        }
    }

    public void activateSolution(){
        foreach(GameObject g in solutionMechanic){
            g.SetActive(true);
        }
    }
}
