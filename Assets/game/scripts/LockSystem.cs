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
        grabInteractable = gameObject.GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    public void unlockDoor(){
        rigidBody.isKinematic = false;
        grabInteractable.enabled = true;

    }

    public void lockDoor(){
        rigidBody.isKinematic = true;
        grabInteractable.enabled = false;
    }

    void Update(){}
}
