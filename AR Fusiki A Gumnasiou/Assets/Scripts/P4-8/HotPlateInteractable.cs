using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlateInteractable : MonoBehaviour
{
    PlayerController pController;
    [SerializeField] HotPlate hotplate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hotplate.glassIsOnPlate)
        {
            pController = other.GetComponent<PlayerController>();
            if(hotplate.IsOn)
            {
                hotplate.CloseHotPlate();
            }
            else
            {
                hotplate.OpenHotPlate();
            }
        }
    }
}
