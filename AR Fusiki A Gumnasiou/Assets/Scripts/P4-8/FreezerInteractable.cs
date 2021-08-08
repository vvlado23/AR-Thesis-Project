using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerInteractable : MonoBehaviour
{
    PlayerController pController;
    [SerializeField] HotPlate hotplate;
    [SerializeField] Freezer freezer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pController = other.GetComponent<PlayerController>();
            if (hotplate.IsOn)
            {
                return;
            }
            else
            {
                freezer.AddIceCube();
            }
        }
    }
}
