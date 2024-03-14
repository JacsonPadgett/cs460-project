using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Piece : MonoBehaviour
{
    //Piece Type
    public int type;
    //Piece Rotation
    public int rotation;
    public GameObject attachPoint;

    public void ObjRotation()
    {
        attachPoint.transform.Rotate(90, 0, 0);
        rotation++;

        switch (type)
        {
            //Straight Piece
            case 1:
                if(rotation > 2)
                {
                    rotation = 1;
                }
                break;
            //90 degree piece
            case 2:
            //T-Piece
            case 3:
                if(rotation > 4) 
                {
                    rotation = 1;
                }
                break;
            //Cross Piece
            case 4:
                rotation = 0;
                break;
            default:
                Debug.Log("Piece needs to be assigned ID!", this);
                break;

        }
    }

    public void resetRotation()
    {
        Debug.Log("Resetting Attach Point Rotation!");
        attachPoint.transform.localEulerAngles = Vector3.zero;
        if(type != 4)
        {
            rotation = 1;
        }
    }
}