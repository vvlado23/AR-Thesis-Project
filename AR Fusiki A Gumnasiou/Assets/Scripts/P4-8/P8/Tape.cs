using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape : MonoBehaviour
{
    [SerializeField] GameObject tapePart;
    [SerializeField] LampInteractable lampInteractable;
    [SerializeField] LampTempertureController controller;
    [SerializeField] float maxTemp = 27;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            tapePart.SetActive(true);
            controller.maxTemp = maxTemp;
            if(lampInteractable.lampIsOn)
                lampInteractable.ChangeThermometersTemperture();
        }
    }
}
