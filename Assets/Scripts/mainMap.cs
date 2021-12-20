using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mainMap : MonoBehaviour
{
    public GameObject emsTabMap;
    public GameObject sfTabMap;
    public GameObject combinedMap;
    public GameObject mainSfMap;
    public GameObject mainEmsMap;
    public GameObject mainBaseMap;
    public TextMeshProUGUI mainText;
    private string defaultText;
    private string altText;

    // Start is called before the first frame update
    void Start()
    {
        mainEmsMap.SetActive(false);
        defaultText = "Aggregated and Normalized Data Covering 2011-2016 by Zip Code";
        altText = "Aggregated and Normalized Stop and Frisk Data 2011-2016 by Zip Code";
    }

    public void setMaps()
    {
        if (sfTabMap.activeInHierarchy && emsTabMap.activeInHierarchy)
        {
            mainBaseMap.SetActive(true);
            mainText.text = altText;
        }
        else
        {
            mainBaseMap.SetActive(false);
            mainText.text = defaultText;
        }
        if(sfTabMap.activeInHierarchy || emsTabMap.activeInHierarchy)
        {
            combinedMap.SetActive(false);
        }
        else
        {
            combinedMap.SetActive(true);
        }
        if (sfTabMap.activeInHierarchy && !emsTabMap.activeInHierarchy)
        {
            mainEmsMap.SetActive(true);
        }
        else
        {
            mainEmsMap.SetActive(false);
        }
        if (sfTabMap.activeInHierarchy)
        {
            mainSfMap.SetActive(false);
        }
        else
        {
            mainSfMap.SetActive(true);
        }
    }

    public void setMaps(GameObject yearMap)
    {
        yearMap.SetActive(false);
    }
}
