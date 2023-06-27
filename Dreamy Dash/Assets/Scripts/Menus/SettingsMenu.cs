using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Text jewelsUI;
    public Text starsUI;
    public Text livesUI;

    [SerializeField] private Button toggleMusicButton;
    [SerializeField] private Button toggleAudioButton;

    [SerializeField] private GameObject musicOnSprite;
    [SerializeField] private GameObject musicOffSprite;
    [SerializeField] private GameObject audioOnSprite;
    [SerializeField] private GameObject audioOffSprite;

    private bool isMusicOn = true;
    private bool isAudioOn = true;
    private void Awake()
    {
        RefreshUI();
    }

    void RefreshUI()
    {
        jewelsUI.text = PlayerPrefs.GetInt("Jewels", 0).ToString();
        starsUI.text = PlayerPrefs.GetInt("Stars", 0).ToString();
        livesUI.text = PlayerPrefs.GetInt("Lives", 0).ToString();

    }

    private void Start()
    {
    }

    public void ToggleMusicOn()
    {
        BGmusic.PlayMusic();
        musicOnSprite.SetActive(true);
        musicOffSprite.SetActive(false);
    }
    public void ToggleMusicOff()
    {
        BGmusic.StopMusic();
        musicOnSprite.SetActive(false);
        musicOffSprite.SetActive(true);
    }

    public void ToggleAudioOn()
    {
        UIController.EnableUI();
        audioOnSprite.SetActive(true);
        audioOffSprite.SetActive(false);
    }

    public void ToggleAudioOff()
    {
        UIController.DisableUI();
        audioOnSprite.SetActive(false);
        audioOffSprite.SetActive(true);
    }

}


