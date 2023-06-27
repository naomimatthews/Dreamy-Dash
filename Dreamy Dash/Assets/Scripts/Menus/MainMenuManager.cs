using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text jewelsText;
    public Text starsText;
    public Text livesText;
    public Text highscoreTextUI;

    private const string TotalStarsKey = "TotalStars";
    private const string AccumulatedStarsKey = "AccumulatedStars";

    public GameObject jewelsRewardPanel;
    public GameObject loadingPanel;
    public GameObject dailyRewardsPanel;

    private async void Start()
    {
        RefreshUI();
        try
        {
            await UnityServices.InitializeAsync();
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        }
        catch (ConsentCheckException e)
        {
            // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
        }
    }

    void RefreshUI()
    {
        // Sync game data with UI.
        jewelsText.text = PlayerPrefs.GetInt("Jewels", 0).ToString();
        livesText.text = PlayerPrefs.GetInt("Lives", 0).ToString();
        highscoreTextUI.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        // Retrieve the total stars.
        int totalStars = PlayerPrefs.GetInt("Stars", 0);

        // Update the UI.
        starsText.text = totalStars.ToString();
    }

    public void LoadJewelsRewardPanel()
    {
        jewelsRewardPanel.SetActive(true);
        loadingPanel.SetActive(false);
    }

    public void BackButton()
    {
        jewelsRewardPanel.SetActive(false);
        loadingPanel.SetActive(false);
        dailyRewardsPanel.SetActive(false);
    }
}
