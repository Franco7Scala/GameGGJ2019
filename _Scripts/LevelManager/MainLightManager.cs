using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightManager : MonoBehaviour
{
    public Light mainLightObject;
    public float intensityLightStep = 0.1f;

    private void Start()
    {
        ResetIntensity();
    }

    private void Update()
    {
        if(Debug.isDebugBuild && Input.GetKeyDown(KeyCode.Space))
        {
            IntensityUp();
        }
    }

    public void IntensityUp()
    {
        if(mainLightObject.intensity >= 1)
        {
            return;
        }

        mainLightObject.intensity += intensityLightStep;
    }

    public void IntensityUp(float step)
    {
        if(mainLightObject.intensity >= 1)
        {
            return;
        }

        mainLightObject.intensity += step;
    }

    public void ResetIntensity()
    {
        mainLightObject.intensity = 0;
    }
}