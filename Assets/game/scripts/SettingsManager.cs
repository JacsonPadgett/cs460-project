using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; set; }

    public Button backButton;
    public Slider volumeSlider;
    public GameObject sliderValue;
    public Toggle subtitlesToggle;

    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.SaveVolume(volumeSlider.value);
            SaveManager.Instance.SaveSubtitles(subtitlesToggle.isOn);
        });

        subtitlesToggle.onValueChanged.AddListener((isOn) =>
        {
            // Handle subtitles toggle value change
            Debug.Log("Subtitles toggled: " + isOn);
            // You can apply subtitle changes here if needed
        });

        StartCoroutine(LoadAndApplySettings());
    }

    private IEnumerator LoadAndApplySettings(){
        LoadAndSetVolume();
        LoadAndSetSubtitles();
        yield return new WaitForSeconds(.1f);
    }
    private void LoadAndSetVolume(){
        volumeSlider.value = SaveManager.LoadVolume();
    }
        private void LoadAndSetSubtitles()
    {
        subtitlesToggle.isOn = SaveManager.LoadSubtitles(); // Set subtitles toggle state
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        sliderValue.GetComponent<TextMeshProUGUI>().text = "" + volumeSlider.value + "";
    }
    
    public void TempSaveGame(){
        SaveManager.Instance.SaveGame();
    }

}
