using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSystem : MonoBehaviour
{
    public GameObject destination;
    public GameObject startLight;
    public GameObject endLight;
    public float teleportOffset;

    public float minFlickerTime = .05f;
    public float maxFlickerTime = .2f;

    public GameObject pieceDestination;

    public void teleport(GameObject gameObject){
        if(gameObject != null){
            gameObject.transform.position += new Vector3(teleportOffset,0,destination.transform.position.z-gameObject.transform.position.z);
        }
        else{
            Debug.LogError("Invalid Object...NULL");
        }
    }

    private void OnTriggerEnter(Collider other){
        GameObject target = other.gameObject;

        //Force player to drop any object
        PlayerAspects.instance.leftDirectInteractor.allowSelect = false;
        PlayerAspects.instance.leftRayInteractor.allowSelect = false;
        PlayerAspects.instance.rightDirectInteractor.allowSelect = false;
        PlayerAspects.instance.rightRayInteractor.allowSelect = false;

        if(target.CompareTag("FinalPiece")){
            target.transform.position = pieceDestination.transform.position;
        }
        else{
            StartCoroutine(teleportSequence(target));
        }
        
    }

    IEnumerator teleportSequence(GameObject target){
        yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        startLight.SetActive(false);
        yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        startLight.SetActive(true);
        yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        startLight.SetActive(false);

        endLight.SetActive(false);
        yield return new WaitForSeconds(.5f);
        teleport(target);
        yield return new WaitForSeconds(.5f);
        startLight.SetActive(true);

        yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        endLight.SetActive(true);
        yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        endLight.SetActive(false);
        yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
        endLight.SetActive(true);

        PlayerAspects.instance.leftDirectInteractor.allowSelect = true;
        PlayerAspects.instance.leftRayInteractor.allowSelect = true;
        PlayerAspects.instance.rightDirectInteractor.allowSelect = true;
        PlayerAspects.instance.rightRayInteractor.allowSelect = true;
        yield break;
    }
}
