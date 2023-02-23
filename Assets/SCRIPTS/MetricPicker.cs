using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MetricPicker : XRSocketInteractor
{
    public MetricCateogories _correctCateogory = MetricCateogories.kilometer;

    public int points = 1;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void OnHoverEntering(HoverEnterEventArgs args)
    {
        base.OnHoverEntering(args);
        CompareInteractor(args);
    }
    public void CompareInteractor(HoverEnterEventArgs args)
    {
        var hoveringInteractor = args.interactableObject.transform;
        var metric = hoveringInteractor.GetComponent<MetricObject>();
        if (metric != null && metric._objectCategory == _correctCateogory)
        {
            //Correct metric object
            GameManager.instance.PlayCorrectMetricSound(this.transform.position, metric.gameObject);
            GameManager.instance.AddScore(points);
            //base.allowHover = true;
            //base.OnHoverEntering(args);
        }
        else
        {
            //incorrect
            GameManager.instance.PlayIncorrectMetricSound();
            //base.allowHover = false;
            //base.OnHoverEntering(args);
        }


    }
}
