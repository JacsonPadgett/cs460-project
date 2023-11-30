using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    public GameObject CubeOnPlayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CubeOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(this);
                CubeOnPlayer.SetActive(true);
            }
        }
    }

}
