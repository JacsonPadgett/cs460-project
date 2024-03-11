using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Manager : MonoBehaviour
{
    //public static WP_Manager instance;
    public static WP_Base[] basePieces;
    public static WP_Base[][] baseSet;
    public static int numOfPuzzles = 1;

    // Start is called before the first frame update
    void Start()
    {
        /*(
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            
        }
        */
        basePieces = FindObjectsOfType<WP_Base>();
        WP_Manager.sortPiecestoSets();
    }

    private static void sortPiecestoSets()
    {
        foreach (WP_Base BP in basePieces)
        {
            numOfPuzzles = Math.Max(numOfPuzzles, BP.puzzle_id);
        }

        Debug.Log("Discovered number of puzzles: " + numOfPuzzles);

        baseSet = new WP_Base[numOfPuzzles][];

        for(int i = 0; i < numOfPuzzles; i++)
        {
            int numOfPieces = 0;
            foreach (WP_Base BP in basePieces)
            {
                if(BP.puzzle_id == i + 1)
                {
                    numOfPieces++;
                }
            }
            baseSet[i] = new WP_Base[numOfPieces];
        }

        Debug.Log("Discovered number of pieces to each puzzle");

        for(int i = 0; i < numOfPuzzles; i++)
        {
            int j = 0;
            foreach (WP_Base BP in basePieces)
            {
                if(BP.puzzle_id == i + 1)
                {
                    baseSet[i][j] = BP;
                    j++;
                }
            }
        }

        Debug.Log("Sorted pieces for each puzzle");
    }

    public static void checkSolution(int puzzle_id)
    {
        foreach (WP_Base BP in baseSet[puzzle_id-1])
        {
            if (!BP.isCorrect)
            {
                Debug.Log("Incorrect Solution - Puzzle ID: " + puzzle_id);
                return;
            }
        }

        Debug.Log("Correct Solution - Puzzle ID: " + puzzle_id);
    }

    public static void callToRotate(int puzzle_id)
    {
        Debug.Log("Call made to rotate pieces in Puzzle ID: " + puzzle_id);

        foreach (WP_Base BP in baseSet[puzzle_id-1])
        {
            BP.rotatePiece();
        }

        WP_Manager.checkSolution(puzzle_id);
    }
}
