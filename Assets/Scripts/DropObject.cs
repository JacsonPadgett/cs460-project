using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{

    public GameObject CubePrefab;
    public GameObject CubeOnPlayer;

    // Update is called once per frame
    void Update()
    {
        if (CubeOnPlayer.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(CubePrefab, transform.position, Quaternion.identity);
                CubeOnPlayer.SetActive(false);
            }
        }
        
    }
}
