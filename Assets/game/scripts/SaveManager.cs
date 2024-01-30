using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class SaveManager : MonoBehaviour
{
    public GameObject playerObject;
    PlayerAspects player = PlayerAspects.GetInstance();
    public static SaveManager Instance { get; set; }

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

        DontDestroyOnLoad(gameObject);
    }



    public void SaveGame() // calls all methods to save the game
    {
        AllGameData data = new AllGameData();
        data.playerData = GetPlayerData();

        SaveAllGameData(data);
    }

    private PlayerData GetPlayerData() // retrieves the data from the game
    {
        int playerCurrentLevel = 0; // need a way to track the level
        switch (SceneManager.GetActiveScene().name) //sets the scene to the right level
        {
            case "MainMenu":
                playerCurrentLevel = 0;
                break;
            case "Testing Scene":
                playerCurrentLevel = 1;
                break;
            case "Level 2":
                playerCurrentLevel = 2;
                break;
            case "Level 3":
                playerCurrentLevel = 3;
                break;
            case "Level 4":
                playerCurrentLevel = 4;
                break;
        }

        int[] completedLevels = new int[4];  // empty for now need a way to track completed levels
        int[] inventory = new int[10];  // id for inventory need way to track inventory
        


        // Get the player's position
        Vector3 playerPosition = playerObject.transform.position;

        // Get the player's rotation
        Quaternion playerRotation = playerObject.transform.rotation;

  
        List<int> keysList = PlayerAspects.GetKeys(); // Retrieve the keys as a List<int>
        int[] keysArray = keysList.ToArray(); // Convert the List<int> to an int[]


        // i dont understand why it is saying it wrong but work
        return new PlayerData(playerCurrentLevel, completedLevels, inventory, playerPosition, playerRotation, keysList);
    }

    public void SaveAllGameData(AllGameData gameData) //send the game data to a binary file
    {
        SaveGameDataToBinaryFile(gameData);

    }

    public AllGameData LoadAllGameData() //loads the game data from the binary file
    {
        AllGameData gameData = LoadGameDataFromBinaryFile();
        return gameData;
    }

    public void LoadGame()
    {
        // Player Data
        SetPlayerData(LoadAllGameData().playerData);
        // Enviroment data

    }

    private void SetPlayerData(PlayerData playerData)
    {
        switch (playerData.playerLevel) //sets the scene to the right level
        {
            case 0:
                SceneManager.LoadScene("MainMenu");
                break;
            case 1:
                SceneManager.LoadScene("Testing Scene");
                break;
            case 2:
                SceneManager.LoadScene("Level 2");
                break;
            case 3:
                SceneManager.LoadScene("Level 3");
                break;
            case 4:
                SceneManager.LoadScene("Level 4");
                break;
        }

        // Set the player's position and rotation
        Vector3 playerPosition = playerData.playerPosition.ToVector3();
        Quaternion playerRotation = playerData.playerRotation.ToQuaternion();

        // Set the player's position and rotation in the game
        playerObject.transform.position = playerPosition;
        playerObject.transform.rotation = playerRotation;


        //gets the keys and uses them
        foreach (int key in playerData.keys){
            player.addKey(key);
        }






    }




    // Settings saving
    public void SaveVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeSetting", volume);
        PlayerPrefs.Save();
    }
    public static float LoadVolume()
    {
        return PlayerPrefs.GetFloat("VolumeSetting");
    }

    // Saving the game data 

    public void SaveGameDataToBinaryFile(AllGameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save_game.bin";

        try
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, gameData);
            }

            Debug.Log("Data saved to " + path);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving game data: " + e.Message);
        }
    }

    public AllGameData LoadGameDataFromBinaryFile()
    {
        string path = Application.persistentDataPath + "/save_game.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AllGameData data = formatter.Deserialize(stream) as AllGameData;
            stream.Close();
            Debug.Log("load " );

            return data;

        }
        else
        {
            Debug.Log("no load " );
            return null;
            
        }

    }


}
