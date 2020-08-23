using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void SwitchToCreditsScene()
    {
        SceneManager.LoadScene(sceneName: "Credits");
    }
}
