using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameMusic : MonoBehaviour
{
    public static MainGameMusic instance;
    private AudioSource audioSource;
    private bool isMuted;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        isMuted = false;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "EndlessRunnerScene" && !isMuted)
        {
            PlayMusic();
        }
        else
        {
            StopMusic();
        }
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.volume = isMuted ? 0f : 1f;
    }
}
