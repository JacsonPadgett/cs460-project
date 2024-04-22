using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class randomknock : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip knock;

    void Start()
    {
        GameObject subtitleObject = GameObject.Find("Subtitles");

        audioSource = subtitleObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter()
    {
            // Generate a random number between 0 and 1
            float chance = Random.Range(0.0f, 1.0f);

            // Check if the random number is less than 0.15 (15% chance)
            if (chance <= 0.15f)
            {
                // Play the sound
                audioSource.PlayOneShot(knock);
                StartCoroutine(waitTillDisable());
            }
            
    }
        public IEnumerator waitTillDisable(){
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}