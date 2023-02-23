using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class MetricObject : XRGrabInteractable
{
    public MetricCateogories _objectCategory = MetricCateogories.kilometer;
    public Vector3 getStartingPosition { get; private set; }
    void Start()
    {
        getStartingPosition = this.transform.position;
    }
}
