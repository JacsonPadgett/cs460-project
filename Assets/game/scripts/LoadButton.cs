using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    private SaveManager saveManager;

    private void Start()
    {
        // Find the SaveManager component on the GameManager object in the scene
        GameObject gameManagerObject = GameObject.FindWithTag("Player");
        if (gameManagerObject != null)
        {
            saveManager = gameManagerObject.GetComponent<SaveManager>();
        }

        // Check if SaveManager is found
        if (saveManager != null)
        {
            // Get the Button component attached to this GameObject
            Button loadButton = GetComponent<Button>();

            // Assign the LoadGame function to the button's OnClick event
            if (loadButton != null)
            {
                loadButton.onClick.AddListener(saveManager.LoadGame);
            }
        }
        else
        {
            Debug.LogError("SaveManager not found on GameManager object in the scene.");
        }
    }
}
