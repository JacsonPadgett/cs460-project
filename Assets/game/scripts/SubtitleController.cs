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
    public float changeMe;


    // Update is called once per frame
    void Update()
    {
        subtitle.transform.LookAt(lookAtTarget);

        transform.RotateAround (transform.position, transform.up, changeMe);
        
        Vector3 targetPosition = target.position + (target.forward * distance) + (target.right * horizontalOffset) + (target.up * verticalOffset);

        transform.position += (targetPosition - transform.position) * .025f;

        
    }

    public IEnumerator TypeWriter(int phraseIndex){
        string phrase = phrases[phraseIndex];
        subtitle.text = "";

        for(int i = 0; i < phrase.Length; i++){
            subtitle.text += phrase[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        
        yield break;
    }
}
