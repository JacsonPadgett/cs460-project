using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePiece : MonoBehaviour
{
    public int id;
    public string type;
    
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateRotation(){
            switch(type){
                case "across":
                    image.transform.Rotate(0f, 0.0f, 90.0f, Space.Self);
                    break;
                case "right_up":
                    image.transform.Rotate(0f, 0.0f, 90.0f, Space.Self);
                    break;
                case "right_down":
                    break;
                case "left_up":
                    break;
                case "left_down":
                    image.transform.Rotate(0f, 0.0f, 90.0f, Space.Self);
                    break;
                case "up":
                    break;
                default:
                    Debug.Log("Assign Piece Type");
                    break;
            }
        }

    public void resetRotation(){
        switch(type){
            case "across":
                image.transform.Rotate(0f, 0.0f, -90.0f, Space.Self);
                break;
            case "right_up":
                image.transform.Rotate(0f, 0.0f, -90.0f, Space.Self);
                break;
            case "right_down":
                break;
            case "left_up":
                break;
            case "left_down":
                image.transform.Rotate(0f, 0.0f, -90.0f, Space.Self);
                break;
            case "up":
                break;
            default:
                Debug.Log("Assign Piece Type");
                break;
        }
    }
}   