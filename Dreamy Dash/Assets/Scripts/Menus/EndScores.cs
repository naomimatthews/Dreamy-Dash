using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScores : MonoBehaviour
{
    public TextMeshProUGUI collectedStars;
    public TextMeshProUGUI distanceScore;
    public TextMeshProUGUI highscore;

    public Collectable collectable;
    public DistanceScore distanceScoreScript;

    private void Start()
    {
        collectedStars.text = PlayerController.starCounter.ToString("");
        distanceScore.text = DistanceScore.distance.ToString("");
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString("");
    }
}

