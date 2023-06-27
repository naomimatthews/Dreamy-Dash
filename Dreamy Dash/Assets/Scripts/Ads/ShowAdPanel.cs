using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdPanel : MonoBehaviour
{
    public GameObject jewelsRewardPanel;
    public GameObject loadingPanel;

    public void LoadJewelsRewardPanel()
    {
        jewelsRewardPanel.SetActive(true);
        loadingPanel.SetActive(false);
    }

    public void BackButton()
    {
        jewelsRewardPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }
}
