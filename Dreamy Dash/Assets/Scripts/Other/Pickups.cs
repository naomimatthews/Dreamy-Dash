using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pickups : MonoBehaviour
{
    public float moveSpeed = 17f;

    StarMove starMoveScript;

    void Start()
    {
        starMoveScript = gameObject.GetComponent<StarMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int totalStars = PlayerPrefs.GetInt("TotalStars", 0);
            totalStars++;
            PlayerPrefs.SetInt("TotalStars", totalStars);
            PlayerPrefs.Save();

            AnalyticsResult analyticsResult = Analytics.CustomEvent("Stars Collected: " + totalStars);
            Debug.Log("analyticsResult: " + analyticsResult);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StarDetector")
        {
            starMoveScript.enabled = true;
        }
    }
}


