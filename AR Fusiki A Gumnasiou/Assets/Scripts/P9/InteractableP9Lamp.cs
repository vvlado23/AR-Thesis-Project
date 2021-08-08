using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableP9Lamp : Interactable
{
    bool isOpen = false;
    [SerializeField] GameObject myLight;
    [SerializeField] GlassP9 glass;

    protected override void Interact()
    {
        isOpen = !isOpen;
        myLight.SetActive(isOpen);

        if (glass.p2 || glass.p3)
            return;

        if (isOpen)
            glass.StartP1();
        else
            glass.ResetP();
    }
}
