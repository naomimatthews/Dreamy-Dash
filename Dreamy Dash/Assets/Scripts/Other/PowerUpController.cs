using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    public Text multiplierQuantityText;
    public Text speedBoostQuantityText;
    public Text charmQuantityText;

    public Button multiplierButton;
    public Button speedBoostButton;
    public Button charmButton;

    private void Start()
    {
        multiplierButton.onClick.AddListener(UseMultiplier);
        speedBoostButton.onClick.AddListener(UseSpeedBoost);
        charmButton.onClick.AddListener(UseCharm);
    }

    private void Update()
    {
        // Retrieve data.
        int totalMultiplier = PlayerPrefs.GetInt("Multiplier", 0);
        int totalSpeedBoost = PlayerPrefs.GetInt("SpeedBoost", 0);
        int totalCharm = PlayerPrefs.GetInt("Charm", 0);

        // Update the UI.
        multiplierQuantityText.text = totalMultiplier.ToString();
        speedBoostQuantityText.text = totalSpeedBoost.ToString();
        charmQuantityText.text = totalCharm.ToString();

        multiplierButton.interactable = totalMultiplier > 0;
        speedBoostButton.interactable = totalSpeedBoost > 0;
        charmButton.interactable = totalCharm > 0;
    }

    private void UseMultiplier()
    {
        int totalMultiplier = PlayerPrefs.GetInt("Multiplier", 0);
        if (totalMultiplier > 0)
        {
            // Double the amount of stars collected
            PlayerController.starCounter *= 2;
            Debug.Log("stars collected doubled: " + PlayerController.starCounter);

            totalMultiplier--;
            PlayerPrefs.SetInt("Multiplier", totalMultiplier);
        }
    }

    private void UseSpeedBoost()
    {
        int totalSpeedBoost = PlayerPrefs.GetInt("SpeedBoost", 0);
        if (totalSpeedBoost > 0)
        {
            PlayerController.moveSpeed *= 2;
            Debug.Log("player movement doubled: " + PlayerController.moveSpeed);

            totalSpeedBoost--;
            PlayerPrefs.SetInt("SpeedBoost", totalSpeedBoost);
        }
    }

    private void UseCharm()
    {
        int totalCharm = PlayerPrefs.GetInt("Charm", 0);
        if (totalCharm > 0)
        {
            // Add your charm logic here.

            totalCharm--;
            PlayerPrefs.SetInt("Charm", totalCharm);
        }
    }
}
