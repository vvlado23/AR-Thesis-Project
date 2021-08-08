using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGlassInteractable : MonoBehaviour
{
    bool glassInside = false;
    PlayerController pController;

    [Header("Small Glass Positions")]
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;

    [Header("Objects")]
    [SerializeField] LiquidTemperture smallGlass;
    [SerializeField] LiquidTemperture bigGlass;
    [SerializeField] HotPlate hotplate;

    [Header("Tempertures")]
    [SerializeField] float finalTemperture=23f;
    [SerializeField] float upRate = 0.2f;
    [SerializeField] float downRate = 6f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            pController = other.GetComponent<PlayerController>();
            hotplate.CloseHotPlate();
            MoveGlass();
        }
    }

    void MoveGlass()
    {
        if(glassInside)
        {
            smallGlass.transform.position = startPosition;
            smallGlass.CoolDown(30f, 3f);
            bigGlass.CoolDown(20f, 1f);
        }
        else
        {
            smallGlass.transform.position = endPosition;
            smallGlass.CoolDown(finalTemperture+5, downRate);
            bigGlass.Boile(finalTemperture, upRate);

        }
        hotplate.glassIsOnPlate = glassInside;
        glassInside = !glassInside;
        
    }
}
