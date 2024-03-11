using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Piece : MonoBehaviour
{
    public int id;
    public int sub_id;
    public GameObject attachPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjRotation()
    {
        attachPoint.transform.Rotate(90, 0, 0);
        sub_id++;

        switch (id)
        {
            case 1:
                if(sub_id > 2)
                {
                    sub_id = 1;
                }
                break;
            case 2:
            case 3:
                if(sub_id > 4) 
                {
                    sub_id = 1;
                }
                break;
            case 4:
                sub_id = 0;
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
        if(id != 4)
        {
            sub_id = 1;
        }
    }
}