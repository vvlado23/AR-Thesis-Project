using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
    public Material therMaterial;
    float currentTemperture = 50;
    [SerializeField] float materialTempertureHight;
    public float maxTemperture = 110;
    public float minTemperture = -10;
    float tempertureRange;

    private void Start()
    {
        tempertureRange = maxTemperture - minTemperture;
        TempertureToMaterialTemp();
    }

    public void SetCurrentTemperture(float newTemp)
    {
        currentTemperture = newTemp;
        TempertureToMaterialTemp();
    }

    void TempertureToMaterialTemp()
    {
        materialTempertureHight = (currentTemperture - minTemperture) / tempertureRange;
        ChangeMaterialThermometerTemperture();
    }

    void ChangeMaterialThermometerTemperture()
    {
        therMaterial.SetFloat("_Hight", materialTempertureHight);
    }

    private void OnTriggerStay(Collider other)
    {
        TempertureController otherTemp;
        if (otherTemp = other.gameObject.GetComponent<TempertureController>())
        {
            SetCurrentTemperture(otherTemp.temp);
        }
    }

}
