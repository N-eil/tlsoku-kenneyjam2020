using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
