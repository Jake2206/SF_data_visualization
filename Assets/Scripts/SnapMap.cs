using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMap : MonoBehaviour
{
    /* If map collides with another map snap to other map when trigger is released
     * 
     */

    private bool snap;
    private Transform otherMap;
    private GameObject combined;
    private GameObject ems;

    // Start is called before the first frame update
    void Start()
    {
        ems = GameObject.Find("Map all ems");
        combined = GameObject.Find("Map all combined");
        combined.SetActive(false);
    }

    private void Update()
    {
        if (transform.parent && transform.parent.gameObject.CompareTag("controller")
            && (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger)
            || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)))
        {
            transform.position = otherMap.transform.position;
            transform.rotation = otherMap.transform.rotation;
            ems.SetActive(false);
            combined.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Map"))
        {
            //Debug.Log("collision!");
            if (transform.parent && transform.parent.gameObject.CompareTag("controller"))
            {
                otherMap = collider.transform;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Map"))
        {
            if (transform.parent && transform.parent.gameObject.CompareTag("controller"))
            {
                //Debug.Log(transform.name);
                ems.SetActive(true);
                combined.SetActive(false);
                otherMap = null;
            }
        }
    }
}
