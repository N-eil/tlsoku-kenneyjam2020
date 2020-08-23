using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        GameObject.FindGameObjectWithTag(Constants.MUSIC_PLAYER_TAG).GetComponent<MusicPlayer>().PlayButtonClickClip();
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void SwitchToInstructionsScene()
    {
        GameObject.FindGameObjectWithTag(Constants.MUSIC_PLAYER_TAG).GetComponent<MusicPlayer>().PlayButtonClickClip();
        SceneManager.LoadScene(sceneName: "Instructions");
    }
}
