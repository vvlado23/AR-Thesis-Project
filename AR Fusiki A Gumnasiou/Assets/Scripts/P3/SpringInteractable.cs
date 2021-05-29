using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringInteractable : MonoBehaviour
{
    [SerializeField] Spring mySpring;
    [SerializeField] PlayerController pController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform item;
            if (pController.isHolding)
            {
                item = mySpring.AddItem(pController);
            }
            else
            {
                item = mySpring.ResetSize();
            }
            if (!item) return;
            pController.PickUpItem(item);
        }
    }
}
