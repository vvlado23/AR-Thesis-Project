using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    [SerializeField] AnalogClock analogClock;
    [SerializeField] DigitalClock digitalClock;

    private void OnCollisionEnter(Collision collision)
    {
        Transform item = collision.gameObject.transform;
        DisableGravity(item);
        StopClocks();
    }

    void DisableGravity(Transform item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.isKinematic = false;
        item.GetChild(0).GetComponent<Collider>().isTrigger = true;

    }

    void StopClocks()
    {
        analogClock.StopTime();
        digitalClock.StopTime();
    }
}
