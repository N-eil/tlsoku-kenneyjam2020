using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    public void StartLevel(int level)
    {
        GameObject.FindGameObjectWithTag(Constants.MUSIC_PLAYER_TAG).GetComponent<MusicPlayer>().PlayButtonClickClip();
        int levelNumber = PersistentVariables.currentLevel;
        if (level != 0)
        {
            levelNumber = level;
        }
        if (levelNumber == 1)
        {
            SceneManager.LoadScene(sceneName:"Level1");
        }
        else if (levelNumber == 2)
        {
            SceneManager.LoadScene(sceneName: "Level2");
        }
        StartGameplay();
    }

    public void StartGameplay()
    {
        GameObject.FindGameObjectWithTag(Constants.MUSIC_PLAYER_TAG).GetComponent<MusicPlayer>().PlayGameplayMusic();
    }
}
