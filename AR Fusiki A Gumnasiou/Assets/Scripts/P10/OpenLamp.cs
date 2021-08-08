using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLamp : MonoBehaviour
{
    [SerializeField] GameObject circuit;
    private void Start()
    {
        StartCoroutine(WaitAndLightLamp(2f));
    }

    IEnumerator WaitAndLightLamp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        circuit.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
