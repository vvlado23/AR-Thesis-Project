using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTempertureController : MonoBehaviour
{
    Thermometer thermometer;
    public float minTemp = 23;
    public float maxTemp = 27;

    private void Start()
    {
        thermometer = GetComponent<Thermometer>();
    }

    public void ChangeThermometerTemperture(bool openLamp)
    {
        if(openLamp)
        {
            thermometer.SetCurrentTemperture(maxTemp);
        }
        else
        {
            thermometer.SetCurrentTemperture(minTemp);
        }
    }
}
