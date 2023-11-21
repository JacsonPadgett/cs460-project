using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class ObtainKey : MonoBehaviour
{
    public int keyID;
    // Start is called before the first frame update
    void Start()
    {}
    
    public void obtain(){
        PlayerAspects.instance.addKey(keyID);
        Destroy(this.gameObject);
    }
}
