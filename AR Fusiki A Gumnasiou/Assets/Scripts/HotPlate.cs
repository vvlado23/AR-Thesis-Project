using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlate : MonoBehaviour
{
    public Material plateMaterial;
    [SerializeField] Color onColor;
    [SerializeField] Color offColor;

    public bool IsOn = false;

    private void Update()
    {
        if(IsOn)
        {
            OpenHotPlate();
        }
        else
        {
            CloseHotPlate();
        }
    }

    public void OpenHotPlate()
    {
        IsOn = true;
        plateMaterial.SetColor("_BaseColor", onColor);
    }

    public void CloseHotPlate()
    {
        IsOn = false;
        plateMaterial.SetColor("_BaseColor", offColor);
    }
}
