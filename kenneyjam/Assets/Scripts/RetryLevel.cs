using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(sceneName:"Level1");
        StartGameplay();
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(sceneName: "Level2");
        StartGameplay();
    }

    public void StartGameplay()
    {
        GameObject.FindGameObjectWithTag(Constants.MUSIC_PLAYER_TAG).GetComponent<MusicPlayer>().PlayGameplayMusic();
    }
}
