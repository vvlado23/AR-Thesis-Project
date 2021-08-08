using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableP1 : Interactable
{
    [SerializeField] GameObject openCircuit;
    [SerializeField] GameObject closeCircuit;

    bool isOpen = true;

    protected override void Interact()
    {
        isOpen = !isOpen;
        openCircuit.SetActive(isOpen);
        closeCircuit.SetActive(!isOpen);
    }
}
