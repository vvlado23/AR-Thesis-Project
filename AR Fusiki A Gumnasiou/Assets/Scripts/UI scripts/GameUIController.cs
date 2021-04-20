using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;//Sets the screen to be portret or landscape automaticly
    }

    void Update()
    {
        //if phone user tuch the back button 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
