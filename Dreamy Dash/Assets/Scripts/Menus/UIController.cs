using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    private static bool isEnabled = true;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static void EnableUI()
    {
        if (instance != null && instance.gameObject != null)
        {
            instance.gameObject.SetActive(true);
            isEnabled = true;
        }
    }

    public static void DisableUI()
    {
        if (instance != null && instance.gameObject != null)
        {
            instance.gameObject.SetActive(false);
            isEnabled = false;
        }
    }
}
