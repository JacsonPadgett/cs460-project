using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAspects : MonoBehaviour
{
    public static PlayerAspects instance;
    public static List<int> keys = new List<int>();
    public LockSystem[] doors;



    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }
        else{
            instance = this;
            doors = FindObjectsOfType<LockSystem>();
        }

        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKey(int keyID){
        if(!keys.Contains(keyID)){
            keys.Add(keyID);
            Debug.Log("added key with id: " + keyID);

            foreach (LockSystem door in doors)
            {
                if(door.lockID == keyID){
                    door.unlockDoor();
                }
            }
        }
    }

    public bool search(int keyID){
        if(keys.Contains(keyID)){
            return true;
        }
        else{
            return false;
        }
    }

        // Static method to access the instance
    public static PlayerAspects GetInstance()
    {
        return instance;
    }


    public static List<int> GetKeys(){
        return keys;
    }
}
