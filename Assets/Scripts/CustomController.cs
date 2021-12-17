using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was adapted from the SnapMusic project that I (Jake) worked on last semester in 4172
public class GogoSettings
{
    public const float Alpha = 15.0f;
    public const float D = 0.35f;
    public const float MaxChange = 1.0f;
}

public class CustomController : OVRGrabber
{
    public Transform m_headPose;
    public GameObject ray;
    public Renderer[] controllerRenderers;


    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        float trigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller);
        float dist = (m_headPose.position - m_parentTransform.position).magnitude;
        float location = 0.0f;
        if (trigger > 0.0f && dist > GogoSettings.D)
        {
            location = (trigger * GogoSettings.Alpha) * Mathf.Pow(dist - GogoSettings.D, 2);
        }
        foreach (Renderer controllerRenderer in controllerRenderers)
            controllerRenderer.enabled = trigger > 0.0f && location > 0.025f;

        m_anchorOffsetPosition = new Vector3(0, 0, location);
        m_gripTransform.localPosition = m_anchorOffsetPosition;
        ray.transform.localPosition = new Vector3(0, -0.01f, location / 2.0f);
        ray.transform.localScale = new Vector3(0.015f, Mathf.Max((location - 0.025f) / 2.0f, 0f), 0.015f);
        //m_prevLocation = location;
    }

}