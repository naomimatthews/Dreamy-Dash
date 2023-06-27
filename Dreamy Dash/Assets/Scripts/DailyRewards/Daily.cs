using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daily : MonoBehaviour
{
    public int lastDate;
    public GameObject rewardsPanel; 

    public int[] days;
    public GameObject[] checkObjects;
    public Button[] rewardButtons;

    private void Start()
    {
        days = new int[5];
        for (int i = 0; i < 5; i++)
        {
            days[i] = PlayerPrefs.GetInt("day" + (i + 1), 0);
        }

        lastDate = PlayerPrefs.GetInt("LastDate");

        if (lastDate != System.DateTime.Now.Day)
        {
            PlayerPrefs.SetInt("LastDate", System.DateTime.Now.Day);
            rewardsPanel.SetActive(true);
        }
        else
        {
            bool allRewardsClaimed = true;
            for (int i = 0; i < 5; i++)
            {
                if (days[i] != 2)
                {
                    allRewardsClaimed = false;
                    break;
                }
            }

            if (allRewardsClaimed)
            {
                rewardsPanel.SetActive(false);
            }
        }

        Reward();
    }


    public void Reward()
    {
        for (int i = 0; i < 5; i++)
        {
            if (days[i] == 0)
            {
                checkObjects[i].SetActive(false);
                rewardButtons[i].interactable = false;
            }
            else if (days[i] == 1)
            {
                checkObjects[i].SetActive(false);
                rewardButtons[i].interactable = false;
            }
            else if (days[i] == 2)
            {
                checkObjects[i].SetActive(true);
                rewardButtons[i].interactable = false; 
            }
        }
    }

    public void GetReward(int rewardIndex)
    {
        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);

        switch (rewardIndex)
        {
            case 0:
                Debug.Log("150 stars");
                break;
            case 1:
                Debug.Log("25 revives");
                break;
            case 2:
                Debug.Log("5 jewels");
                break;
            case 3:
                Debug.Log("35 revives");
                break;
            case 4:
                Debug.Log("2500 stars, 50 revives, 15 jewels");
                break;
        }

        days[rewardIndex] = 2;
        PlayerPrefs.SetInt("day" + (rewardIndex + 1), 2);

        Reward();
    }
}

