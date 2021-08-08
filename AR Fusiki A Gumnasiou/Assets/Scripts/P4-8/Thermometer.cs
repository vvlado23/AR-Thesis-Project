using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Thermometer : MonoBehaviour
{
    [Header("Thermometer Variables")]
    public Renderer therMaterialRenderer;
    [SerializeField] float currentTemperture = 50;
    [SerializeField] float materialTempertureHight;
    public float maxTemperture = 130;
    public float minTemperture = -40;
    float tempertureRange;

    [Header("UI text")]
    [SerializeField] bool useUiText = true;
    [SerializeField] TextMeshProUGUI tempertureText;
    [SerializeField] Transform textPivot;

    private void Start()
    {
        tempertureRange = maxTemperture - minTemperture;
        TempertureToMaterialTemp();
        if(!useUiText)
        {
            tempertureText.text = "";
        }
    }

    void Update()
    {
        if(useUiText)
        {
            MoveUIText();
        }
    }

    void MoveUIText()
    {
        Vector3 textPos = Camera.main.WorldToScreenPoint(textPivot.position);
        tempertureText.transform.position = textPos;
        tempertureText.text = currentTemperture.ToString("F1") + " C"; // to ToString("F1") epistrefei ton arithmo me 1 dekadiko psifio
    }

    public void SetCurrentTemperture(float newTemp)
    {
        currentTemperture = newTemp;
        TempertureToMaterialTemp();
    }

    void TempertureToMaterialTemp()
    {
        materialTempertureHight = Mathf.InverseLerp(minTemperture, maxTemperture, currentTemperture);
        //materialTempertureHight = (currentTemperture - minTemperture) / tempertureRange;
        ChangeMaterialThermometerTemperture();
    }

    void ChangeMaterialThermometerTemperture()
    {
        therMaterialRenderer.material.SetFloat("_Hight", materialTempertureHight);
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
