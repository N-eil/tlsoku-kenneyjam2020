using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(sceneName:"Level1");
    }
}
