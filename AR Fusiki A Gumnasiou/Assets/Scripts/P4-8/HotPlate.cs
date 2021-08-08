using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlate : MonoBehaviour
{
    public Material plateMaterial;
    [SerializeField] Color onColor;
    [SerializeField] Color offColor;

    [SerializeField] LiquidTemperture liquidTemperture;

    [SerializeField] float maxTemperture=100f;
    [SerializeField] float rateOfTempertureChange = 1f;

    public bool IsOn = false;
    public bool glassIsOnPlate = true;

    private void Start()
    {
        CloseHotPlate();
    }

    public void OpenHotPlate()
    {
        IsOn = true;
        liquidTemperture.Boile(maxTemperture, rateOfTempertureChange);
        plateMaterial.SetColor("_BaseColor", onColor);
    }

    public void CloseHotPlate()
    {
        IsOn = false;
        liquidTemperture.StopBoile();
        plateMaterial.SetColor("_BaseColor", offColor);
    }
}
