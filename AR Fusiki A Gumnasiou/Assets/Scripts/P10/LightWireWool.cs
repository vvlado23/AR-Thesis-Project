using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWireWool : MonoBehaviour
{
    [SerializeField] GameObject circuit;
    [SerializeField] GameObject interactable;
    private void Start()
    {
        StartCoroutine(WaitAndLight(2f));
    }

    IEnumerator WaitAndLight(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        circuit.SetActive(true);
        interactable.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
