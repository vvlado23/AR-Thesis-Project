using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;

    GameObject currentPanel;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;//sets the screen to be portret in main menu only
        currentPanel = mainMenuPanel;
    }

    void Update()
    {
        //if phone user tuch the back button 
        if(Input.GetKeyDown(KeyCode.Escape) && !currentPanel.Equals(mainMenuPanel))
        {
            ChangePanel(mainMenuPanel);
        }
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void ChangePanel(GameObject nextPanel)
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
        currentPanel = nextPanel;
    }

    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);
    }
}
