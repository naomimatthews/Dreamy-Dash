using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
   public static BGmusic instance;
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

    public static void StopMusic()
    {
        if (instance != null && instance.gameObject != null)
        {
            instance.gameObject.SetActive(false);
        }
    }

    public static void PlayMusic()
    {
        if (instance != null && instance.gameObject != null)
        {
            instance.gameObject.SetActive(true);
        }
    }

}
