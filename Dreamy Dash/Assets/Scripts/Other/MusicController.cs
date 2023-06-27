using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public MainGameMusic musicPlayer;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "YourButtonsSceneName")
        {
            // Enable the buttons
            EnableButtons();
        }
        else
        {
            // Disable the buttons
            DisableButtons();
        }
    }

    public void PlayMusic()
    {
        musicPlayer.PlayMusic();
    }

    public void StopMusic()
    {
        musicPlayer.StopMusic();
    }

    private void EnableButtons()
    {
        // Enable the buttons that control the music
        // (e.g., enable mute button, play button, stop button)
    }

    private void DisableButtons()
    {
        // Disable the buttons that control the music
        // (e.g., disable mute button, play button, stop button)
    }
}

