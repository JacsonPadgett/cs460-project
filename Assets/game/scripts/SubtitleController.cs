using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SubtitleController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform lookAtTarget;
    [SerializeField] float distance;
    [SerializeField] float horizontalOffset;
    [SerializeField] float verticalOffset;
    [SerializeField] TextMeshPro subtitle;
    [SerializeField] string[] phrases;
    [SerializeField] float typingSpeed;
    [SerializeField] float clearSpeed;
    public float changeMe;


    // Update is called once per frame
    void Update()
    {
        subtitle.transform.LookAt(lookAtTarget);

        transform.RotateAround (transform.position, transform.up, changeMe);
        
        Vector3 targetPosition = target.position + (target.forward * distance) + (target.right * horizontalOffset) + (target.up * verticalOffset);

        transform.position += (targetPosition - transform.position) * .025f;

        
    }

    public void startTypeWriter(string phrase){
        StartCoroutine(TypeWriter(phrase));
    }

    public IEnumerator TypeWriter(string phrase){
        subtitle.text = "";

        for(int i = 0; i < phrase.Length; i++){
            subtitle.text += phrase[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(clearSpeed);
        subtitle.text = "";
        
        yield break;
    }
}