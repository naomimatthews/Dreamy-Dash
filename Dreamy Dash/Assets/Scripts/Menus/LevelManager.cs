using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("EndlessRunnerScene");
        BGmusic.instance.GetComponent<AudioSource>().Pause();
        Time.timeScale = 1;
    }

    public void ShopButton()
    {
        SceneManager.LoadScene("ShopScreen");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void RestartButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale = 1;
    }

    public void ShopXButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}

