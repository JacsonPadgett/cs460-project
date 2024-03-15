using UnityEngine;
using UnityEngine.XR;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float movementThreshold = 0.1f; 
    private AudioSource audioSource;
    private Vector3 lastPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the distance moved to know if the palyer moved 
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        // Check if the distance moved exceeds the threshold
        if (distanceMoved > movementThreshold && !audioSource.isPlaying)
        {

            // Play a random footstep sound from the array
            AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(footstepSound);

            // Update last position
            lastPosition = transform.position;
        }
    }
}
