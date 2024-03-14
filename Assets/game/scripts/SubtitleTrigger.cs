using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
    [SerializeField] SubtitleController subtitleController;
    void OnTriggerEnter(Collider other){
        StartCoroutine(subtitleController.TypeWriter(Random.Range(0,10)));
    }
}
