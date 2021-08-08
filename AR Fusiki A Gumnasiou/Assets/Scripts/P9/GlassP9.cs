using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassP9 : MonoBehaviour
{
    TempertureController temp;
    [SerializeField] Thermometer thermometer;
    float targetTemp = 21;
    float tempertureChangeRate = 1f;

    bool hasCap = false;
    bool hasBottle = false;
    bool lampIsOn = false;

    public bool p1 = false;
    public bool p2 = false;
    public bool p3 = false;

    private void Start()
    {
        temp = GetComponent<TempertureController>();
    }

    private void Update()
    {
        if(p1)
        {
            targetTemp = 26;
        }
        else if(p2)
        {
            targetTemp = 33;
        }
        else if(p3)
        {
            targetTemp = 36;
        }
        else
        {
            targetTemp = 21;
            temp.temp = 21;
        }

        if (temp.temp < targetTemp)
            temp.temp += tempertureChangeRate * Time.deltaTime;

        thermometer.SetCurrentTemperture(temp.temp);
    }

    public void ResetP()
    {
        p1 = false;
        p2 = false;
        p3 = false;
        lampIsOn = false;
    }

    public void StartP1()
    {
        p1 = true;
        p2 = false;
        p3 = false;
        lampIsOn = true;
        StartP2();
    }

    public void AddCap()
    {
        hasCap = true;
        StartP2();
    }

    public void AddBottle()
    {
        hasBottle = true;
        StartP2();
    }

    void StartP2()
    {
        if(hasCap && hasBottle && lampIsOn)
        {
            p1 = false;
            p2 = true;
            p3 = false;
        }  
    }

    public void StartP3()
    {
        if (hasCap && hasBottle && lampIsOn)
        {
            p1 = false;
            p2 = false;
            p3 = true;
        }
    }

}
