using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassP7 : MonoBehaviour
{
    PlayerController pController;
    [SerializeField]Transform icePosition;
    [SerializeField] bool isOil;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pController = other.GetComponent<PlayerController>();

            GameObject item = pController.GetItemHolding();
            if(pController.isHolding && item.GetComponent<Cap>().frozen)//an krataei kapaki kai einai pagwmeno
            {
                Cap cap = item.GetComponent<Cap>();
                if(isOil.Equals(cap.isOil))
                    cap.IceToGlass(icePosition, pController);
            }
        }
    }
}
