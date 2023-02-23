using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var metricObject = other.GetComponent<MetricObject>();

        if( metricObject != null)
        {
            metricObject.transform.position = metricObject.getStartingPosition;
        }
    }
}
