using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pasueMenu;
    public static bool isPaused;
    public InputActionReference toggleReference = null;


    void Awake(){
        toggleReference.action.started += Toggle;
    }
    // Start is called before the first frame update
    void Start()
    {
        pasueMenu.SetActive(false);
        pasueMenu.transform.position += Vector3.up * 1f;
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void PauseGame()
    {
        pasueMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        //pasueMenu.transform.position += transform.position + Vector3.up * 3f;
    }

    public void ResumeGame()
    {
        pasueMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //transform.position += transform.position + Vector3.up * -3f;
    }

    public void Toggle(InputAction.CallbackContext context){
        bool isPaused = !pasueMenu.activeSelf;

        if(isPaused){
            PauseGame();
        }
        else{
            ResumeGame();
        }
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Vector3 postion = new Vector3(0, 2, -1.5f);
        FindObjectOfType<SceneController>().SwitchScene("MainMenu", postion);
        isPaused = false;
    }

    
}
