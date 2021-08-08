using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidWithIce : MonoBehaviour
{
    [SerializeField] GameObject iceCubes;
    [SerializeField] HotPlate hotPlate;
    LiquidTemperture liquidTemp;
    bool hasIce = false;
    Vector3 iceCubesSize;

    private void Start()
    {
        liquidTemp = GetComponent<LiquidTemperture>();
        iceCubesSize = iceCubes.transform.localScale;
    }

    private void Update()
    {
        if(hotPlate.IsOn && hasIce)
        {
            iceCubes.transform.localScale = iceCubesSize * Mathf.InverseLerp(35f, 0f, liquidTemp.temperture.temp);
            if (liquidTemp.temperture.temp >= 35)
            {
                MeltIce();
            }
        }
        
    }

    void MeltIce()
    {
        hasIce = false;
        iceCubes.SetActive(false);
    }

    public void AddIceCubes()
    {
        hasIce = true;
        iceCubes.SetActive(true);
        iceCubes.transform.localScale = iceCubesSize;
    }
}
