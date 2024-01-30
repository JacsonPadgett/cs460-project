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

    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            SaveManager.Instance.SaveVolume(volumeSlider.value);
        });

        StartCoroutine(LoadAndApplySettings());
    }

    private IEnumerator LoadAndApplySettings(){
        LoadAndSetVolume();
        yield return new WaitForSeconds(.1f);
    }
    private void LoadAndSetVolume(){
        volumeSlider.value = SaveManager.LoadVolume();
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
