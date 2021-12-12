using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMap : MonoBehaviour
{
    /* If map collides with another map snap to other map when trigger is released
     * 
     */

    private bool snap;
    private bool inHand;
    private Transform otherMap;

    // Start is called before the first frame update
    void Start()
    {
        snap = false;
    }

    private void Update()
    {
        if ((snap && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            || (snap && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)))
        {
            transform.position = otherMap.transform.position;
            transform.rotation = otherMap.transform.rotation;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision!");
        if (collider.gameObject.CompareTag("Map"))
        {
            snap = true;
            otherMap = collider.transform;
            Debug.Log("collision!");
        }
        if (collider.gameObject.CompareTag("controller"))
        {
            inHand = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Map"))
        {
            snap = false;
            otherMap = null;
        }
        if (collider.gameObject.CompareTag("controller"))
        {
            inHand = false;
        }
    }


}
