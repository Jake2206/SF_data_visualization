using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMap : MonoBehaviour
{
    public GameObject emsTabMap;
    public GameObject sfTabMap;
    public GameObject combinedMap;
    public GameObject mainSfMap;
    public GameObject mainEmsMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setMaps()
    {
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
}
