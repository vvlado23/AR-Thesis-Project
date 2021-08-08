using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampInteractable : MonoBehaviour
{
    PlayerController pController;
    public bool lampIsOn = false;

    [SerializeField] GameObject lightLamp;
    [SerializeField] LampTempertureController[] thermometerControllers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pController = other.GetComponent<PlayerController>();
            lampIsOn = !lampIsOn;
            lightLamp.SetActive(lampIsOn);

            ChangeThermometersTemperture();
        }
    }

    public void ChangeThermometersTemperture()
    {
        foreach (LampTempertureController ther in thermometerControllers)
        {
            ther.ChangeThermometerTemperture(lampIsOn);
        }
    }
}
