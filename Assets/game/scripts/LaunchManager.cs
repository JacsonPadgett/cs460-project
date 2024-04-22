using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public Light leftLight;
    public Light rightLight;
    public GameObject gameLogo;
    public GameObject studioLogo;

    public float fadeTime;

    public bool skip;

    void Start(){
        if(skip){
            pauseMenu.GoToMainMenu();
        }
        StartCoroutine(TitleSequence());
    }

    IEnumerator TitleSequence(){
        yield return new WaitForSeconds(1f);

        float intensity = 0;

        while(intensity != 100){
            intensity += 2;
            
            leftLight.intensity = intensity;
            rightLight.intensity = intensity;

            yield return new WaitForSeconds(.05f);
        }

        intensity = 100;
        leftLight.intensity = intensity;
        rightLight.intensity = intensity;
        yield return new WaitForSeconds(1.5f);

        while(intensity != 0){
            intensity -= 2;
            
            leftLight.intensity = intensity;
            rightLight.intensity = intensity;

            yield return new WaitForSeconds(.05f);
        }

        intensity = 0;
        leftLight.intensity = intensity;
        rightLight.intensity = intensity;
        studioLogo.SetActive(false);
        gameLogo.SetActive(true);
        yield return new WaitForSeconds(.5f);

        while(intensity != 100){
            intensity += 2;
            
            leftLight.intensity = intensity;
            rightLight.intensity = intensity;

            yield return new WaitForSeconds(.05f);
        }
        
        intensity = 100;
        leftLight.intensity = intensity;
        rightLight.intensity = intensity;
        yield return new WaitForSeconds(1.5f);

        while(intensity != 0){
            intensity -= 2;
            
            leftLight.intensity = intensity;
            rightLight.intensity = intensity;

            yield return new WaitForSeconds(.05f);
        }

        intensity = 0;
        leftLight.intensity = intensity;
        rightLight.intensity = intensity;
        yield return new WaitForSeconds(1.5f);

        pauseMenu.GoToMainMenu();
        yield break;
    }
}
