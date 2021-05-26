using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] AnalogClock analogClock;
    [SerializeField] DigitalClock digitalClock;
    [SerializeField] PlayerController pController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject mySphare = pController.PutDownItem(transform.parent.parent, startPosition.position);
            if(mySphare)
            {
                EnableGravity(mySphare.transform);
                StartClocks();
            }
        }
    }

    void EnableGravity(Transform item)
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetChild(0).GetComponent<Collider>().isTrigger = false;
    }

    void StartClocks()
    {
        analogClock.StartTime();
        digitalClock.StartTime();
    }
}
