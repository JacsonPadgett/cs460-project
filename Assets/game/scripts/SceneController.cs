using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneController : MonoBehaviour
{
     public GameObject playerObject;

    // Method to switch to a new scene and teleport the player
    public void SwitchScene(string sceneName, Vector3 teleportCoordinates)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        TeleportPlayer(teleportCoordinates);
    }

    // Teleports the player to the specified coordinates
    private void TeleportPlayer(Vector3 teleportCoordinates)
    {
        playerObject.transform.position = teleportCoordinates;
    }
}
