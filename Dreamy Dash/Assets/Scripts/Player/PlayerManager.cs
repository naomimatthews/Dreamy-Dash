using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if (gameOver)
        {
            StartCoroutine(ActivateGameOverPanel());
        }
    }

    IEnumerator ActivateGameOverPanel()
    {
        yield return new WaitForSeconds(3f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
