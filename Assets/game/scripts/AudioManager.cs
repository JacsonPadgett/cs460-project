using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    [SerializeField] AudioSource SFXSource;
    public SubtitleController subtitleController;



    void Start()
    {
        // Add listener to the slider to detect changes in volume
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    public void PlaySFX(AudioClip clip, string text){
        SFXSource.PlayOneShot(clip);
        subtitleController.startTypeWriter(text);
    }

    void UpdateVolume(float volume)
    {
        // Update the volume of all audio sources in the scene
        AudioListener.volume = volume;
    }
}
