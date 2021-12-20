using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnapMap : MonoBehaviour
{
    /* If map collides with another map snap to other map when trigger is released
     * 
     */
    private bool snap;
    Vector3 orig_pos;
    Quaternion orig_rot;
    private Transform child;
    private GameObject mainMapParent;
    public TextMeshProUGUI dataExplanation;
    private mainMap mm;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0);
        child.gameObject.SetActive(false);
        orig_pos = transform.position;
        orig_rot = transform.rotation;
        mainMapParent = GameObject.Find("Main map");
        mm = mainMapParent.GetComponent<mainMap>();
        dataExplanation.enabled = false;
    }

    private void Update()
    {
        if (snap
            && (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger)
            || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)))
        {
            transform.position = orig_pos;
            transform.rotation = orig_rot;
            child.gameObject.SetActive(false);
            dataExplanation.enabled = false;
            if (child.name.Contains("year"))
            {
                mm.setMaps(child.gameObject);
            }
            else
            {
                mm.setMaps();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Map"))
        {
            //Debug.Log("Collision!");
            snap = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Map"))
        {
            //Debug.Log("Exit!");
            snap = false;
            child.gameObject.SetActive(true);
            dataExplanation.enabled = true;
            mm.setMaps();
        }
    }
}
