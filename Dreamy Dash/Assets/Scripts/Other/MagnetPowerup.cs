using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerup : MonoBehaviour
{
    public GameObject starDetectorObj;

    void Start()
    {
        starDetectorObj = GameObject.FindGameObjectWithTag("Star Detector");
        starDetectorObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(ActivateStar());
            Destroy(transform.GetChild(0).gameObject);
        }    
    }

    IEnumerator ActivateStar()
    {
        starDetectorObj.SetActive(true);
        yield return new WaitForSeconds(10f);
        starDetectorObj.SetActive(false);

    }
}
