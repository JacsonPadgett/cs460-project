using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class ObtainKey : MonoBehaviour
{
    public int keyID;
    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioManager>();
    }

    public bool masterKey;
    // Start is called before the first frame update
    void Start()
    {}
    
    public void obtain(){
        if(masterKey){
            foreach(LockSystem door in PlayerAspects.instance.doors)
            {
                PlayerAspects.instance.addKey(door.lockID);
                audioManager.PlaySFX(audioManager.keyPickup);
                Destroy(this.gameObject);
            }
        }
        else{
            if(this.gameObject != null){
                PlayerAspects.instance.addKey(keyID);

                Destroy(this.gameObject);
            }
        }
    }
}
