using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleManager : MonoBehaviour
{
    public static WirePuzzleManager instance;
    public BasePiece[] basePieces;

    private bool isSolved = false;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this){
            Destroy(this);
        }
        else{
            instance = this;
            basePieces = FindObjectsOfType<BasePiece>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSolved)
            Debug.Log("Puzzle Solved yay");
    }

    //i am too tired to continue... here is where i left off...i think line 36 may be returning false positives or something IDK..... 
    public void checkPuzzle(){
        bool flag = true;
        while(flag){
            foreach (BasePiece piece in basePieces)
            {
                if(!piece.isCorrect)
                    flag = false;
            }

            isSolved = true;
            flag = false;
        }
    }
}
