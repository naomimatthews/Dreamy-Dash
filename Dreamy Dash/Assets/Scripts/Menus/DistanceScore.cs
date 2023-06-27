using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceScore : MonoBehaviour
{
    public GameObject startPos;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObj;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI highScoreTextGameOver;

    private Vector3 lastPathPosition;
    public static float distance;

    private void Start()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
        lastPathPosition = startPos.transform.position;
        distance = 0f;
        UpdateHighscore();
    }

    void Update()
    {
        Vector3 currentPathPosition = GetPathPosition();
        float currentDistance = CalculateDistance(lastPathPosition, currentPathPosition);
        distance += currentDistance;
        lastPathPosition = currentPathPosition; 
        scoreText.text = Mathf.RoundToInt(distance).ToString("00000");

        UpdateHighscore();
    }


    private Vector3 GetPathPosition()
    {
        PathSpawner pathSpawner = FindObjectOfType<PathSpawner>();
        if (pathSpawner != null && pathSpawner.activePaths.Count > 0)
        {
            Transform lastPath = pathSpawner.activePaths[pathSpawner.activePaths.Count - 1].transform;
            return lastPath.position;
        }

        return lastPathPosition;
    }

    public float CalculateDistance(Vector3 start, Vector3 end)
    {
        return Mathf.CeilToInt(Vector3.Distance(start, end));
    }

    public void UpdateHighscore()
    {
        int currentHighscore = PlayerPrefs.GetInt("HighScore", 0);

        if (distance > currentHighscore)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(distance));
            PlayerPrefs.Save();
        }

        highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString("00000");
        highScoreTextGameOver.text = PlayerPrefs.GetInt("HighScore", 0).ToString("00000");
    }
}

