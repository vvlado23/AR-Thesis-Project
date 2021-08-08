using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerInteractableP7_3 : MonoBehaviour
{
    PlayerController pController;
    [SerializeField] FreezerP7_3 freezer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pController = other.GetComponent<PlayerController>();
            if (freezer.frozen) return;
            freezer.AddIceCube();
        }
    }
}
