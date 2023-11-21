using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockSystem : MonoBehaviour
{
    public Rigidbody rigidBody;
    public XRGrabInteractable grabInteractable;
    public int lockID;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerAspects.instance.search(lockID)){
            rigidBody.isKinematic = false;
            grabInteractable.enabled = true;
        }
    }
}
