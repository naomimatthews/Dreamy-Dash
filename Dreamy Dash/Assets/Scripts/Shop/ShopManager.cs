using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public Text jewelsUI;
    public Text starsUI;
    public Text livesUI;

    public GameObject[] shopPanelsGO;
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    private void Awake()
    {
        RefreshUI();
    }

    void RefreshUI()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);

        jewelsUI.text = PlayerPrefs.GetInt("Jewels", 0).ToString();
        starsUI.text = PlayerPrefs.GetInt("Stars", 0).ToString();
        livesUI.text = PlayerPrefs.GetInt("Lives", 0).ToString();

        CheckPurchaseable();
    }

    public void AddJewels()
    {
        int currentJewels = PlayerPrefs.GetInt("Jewels", 0);
        currentJewels++;
        PlayerPrefs.SetInt("Jewels", currentJewels);
        PlayerPrefs.Save();

        jewelsUI.text = currentJewels.ToString();
        CheckPurchaseable();
    }


    public void AddStars()
    {
        int currentStars = PlayerPrefs.GetInt("Stars", 0);
        currentStars++;
        PlayerPrefs.SetInt("Stars", currentStars);
        PlayerPrefs.Save();

        starsUI.text = currentStars.ToString();
        CheckPurchaseable();
    }

    public void AddLives()
    {
        int currentLives = PlayerPrefs.GetInt("Lives", 0);
        currentLives++;
        PlayerPrefs.SetInt("Lives", currentLives);
        PlayerPrefs.Save();

        livesUI.text = currentLives.ToString();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (CanAfford(shopItemsSO[i]))
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public bool CanAfford(ShopItemSO item)
    {
        switch (item.currencyType)
        {
            case ShopItemSO.CurrencyType.Stars:
                return PlayerPrefs.GetInt("Stars", 0) >= item.amount;
            case ShopItemSO.CurrencyType.Jewels:
                return PlayerPrefs.GetInt("Jewels", 0) >= item.amount;
            case ShopItemSO.CurrencyType.Lives:
                return PlayerPrefs.GetInt("Lives", 0) >= item.amount;
            case ShopItemSO.CurrencyType.IAP:
                // Implement your logic for IAP currency type
                return true;
            default:
                return false;
        }
    }

    public void PurchaseItems(int btnNo)
    {
        var item = shopItemsSO[btnNo];

        if (CanAfford(item))
        {
            switch (item.currencyType)
            {
                case ShopItemSO.CurrencyType.Stars:
                    int currentStars = PlayerPrefs.GetInt("Stars", 0);
                    currentStars -= item.amount;
                    PlayerPrefs.SetInt("Stars", currentStars);
                    PlayerPrefs.Save();
                    starsUI.text = currentStars.ToString();
                    break;
                case ShopItemSO.CurrencyType.Jewels:
                    int currentJewels = PlayerPrefs.GetInt("Jewels", 0);
                    currentJewels -= item.amount;
                    PlayerPrefs.SetInt("Jewels", currentJewels);
                    PlayerPrefs.Save();
                    jewelsUI.text = currentJewels.ToString();
                    break;
                case ShopItemSO.CurrencyType.Lives:
                    int currentLives = PlayerPrefs.GetInt("Lives", 0);
                    currentLives -= item.amount;
                    PlayerPrefs.SetInt("Lives", currentLives);
                    PlayerPrefs.Save();
                    livesUI.text = currentLives.ToString();
                    break;
                case ShopItemSO.CurrencyType.IAP:
                    // Implement your logic for IAP currency type
                    break;
            }

            if (btnNo == 0)
            {
                int multiplierQuantity = PlayerPrefs.GetInt("Multiplier", 0);
                multiplierQuantity += 1;
                PlayerPrefs.SetInt("Multiplier", multiplierQuantity);
            }
            else if (btnNo == 1)
            {
                int speedBoostQuantity = PlayerPrefs.GetInt("SpeedBoost", 0);
                speedBoostQuantity += 1;
                PlayerPrefs.SetInt("SpeedBoost", speedBoostQuantity);
            }
            else if (btnNo == 2)
            {
                int currentLives = PlayerPrefs.GetInt("Lives", 0);
                currentLives += 5;
                PlayerPrefs.SetInt("Lives", currentLives);
                livesUI.text = currentLives.ToString();
            }
            else if (btnNo == 3)
            {
                int charmQuantity = PlayerPrefs.GetInt("Charm", 0);
                charmQuantity += 1;
                PlayerPrefs.SetInt("Charm", charmQuantity);
            }
            else if (btnNo == 4)
            {
                int currentStars = PlayerPrefs.GetInt("Stars", 0);
                currentStars += 10000;
                PlayerPrefs.SetInt("Stars", currentStars);
                livesUI.text = currentStars.ToString();
            }

            PlayerPrefs.Save();
            CheckPurchaseable();
        }
    }


    public void MainMenubutton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}


