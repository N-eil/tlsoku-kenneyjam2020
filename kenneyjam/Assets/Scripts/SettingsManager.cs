using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle FullscreenToggle;
    public Dropdown ResolutionDropdown;
    public Dropdown TextureQualityDropdown;
    public Slider MusicVolumeSlider;

    public AudioSource MusicSource;

    public Resolution[] Resolutions;

    public GameSettings GameSettings;

    private void OnEnable()
    {
        GameSettings = new GameSettings();

        FullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        ResolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        TextureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        MusicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });

        Resolutions = Screen.resolutions;
        foreach (Resolution resolution in Resolutions)
        {
            ResolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        MusicSource = GameObject.FindWithTag(Constants.MUSIC_PLAYER_TAG).GetComponent<AudioSource>();

        if (File.Exists(Application.persistentDataPath + Constants.GAME_SETTINGS_PATH))
            LoadSettings();
        else
            ResolutionDropdown.RefreshShownValue(); // show current resolution
    }

    public void OnFullscreenToggle()
    {
        GameSettings.Fullscreen = Screen.fullScreen = FullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        GameSettings.ResolutionIndex = ResolutionDropdown.value;
        Screen.SetResolution(Resolutions[ResolutionDropdown.value].width, Resolutions[ResolutionDropdown.value].height, Screen.fullScreen);
    }

    public void OnTextureQualityChange()
    {
        GameSettings.TextureQuality = QualitySettings.masterTextureLimit = TextureQualityDropdown.value;
    }

    public void OnMusicVolumeChange()
    {
        GameSettings.MusicVolume = MusicSource.volume = MusicVolumeSlider.value;
    }

    public void SaveSettings()
    {
        GameObject.FindGameObjectWithTag(Constants.MUSIC_PLAYER_TAG).GetComponent<MusicPlayer>().PlayButtonClickClip();
        string jsonData = JsonUtility.ToJson(GameSettings, true);
        File.WriteAllText(Application.persistentDataPath + Constants.GAME_SETTINGS_PATH, jsonData);
    }

    public void LoadSettings()
    {
        GameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + Constants.GAME_SETTINGS_PATH));
        FullscreenToggle.isOn = GameSettings.Fullscreen;
        ResolutionDropdown.value = GameSettings.ResolutionIndex;
        TextureQualityDropdown.value = GameSettings.TextureQuality;
        MusicVolumeSlider.value = GameSettings.MusicVolume;
    }
}
