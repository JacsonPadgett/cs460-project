using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class RandomAILines : MonoBehaviour
{
        public AudioClip[] randomLines;
        public AudioManager audioManager;
        public string[] text;
        private AudioSource audioSource;
        private int index;
        float time;
        float randomTime;
        AudioClip AILine;
        AudioClip lastClip;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        time = 0;

        randomTime = Random.Range(0, 120) +120; // 2 to 4 minutes




    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time == randomTime && !audioSource.isPlaying){

            randomTime = Random.Range(0, 120) +120;
            index = Random.Range(0, randomLines.Length);
            AILine = randomLines[index];
            while (AILine == lastClip){
                index = Random.Range(0, randomLines.Length);
                AudioClip AILine = randomLines[index];
            }
            audioManager.PlaySFX(AILine, text[index]);
            time = 0;

        } else if (time == randomTime && audioSource.isPlaying){
            time -= 10f;
        }
    }
}
