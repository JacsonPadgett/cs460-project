using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("XR Origin (XR Rig)").transform.position = this.gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
