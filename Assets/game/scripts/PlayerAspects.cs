using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAspects : MonoBehaviour
{
    public static PlayerAspects instance;
    private List<int> keys = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this){
            Destroy(this);
        }
        else{
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKey(int keyID){
        keys.Add(keyID);
        Debug.Log("added key with id: " + keyID);
    }

    public bool search(int keyID){
        if(keys.Contains(keyID)){
            return true;
        }
        else{
            return false;
        }
    }
}
