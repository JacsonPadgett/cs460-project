using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource subtitles;

    public AudioClip keyPickup;
    public AudioClip puzzlePieceDown;
    public AudioClip subtitle1;


    void Start()
    {
        // Add listener to the slider to detect changes in volume
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

    void UpdateVolume(float volume)
    {
        // Update the volume of all audio sources in the scene
        AudioListener.volume = volume;
    }
}
