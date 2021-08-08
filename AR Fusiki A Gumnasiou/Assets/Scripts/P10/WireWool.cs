using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireWool : MonoBehaviour
{
    [SerializeField] GameObject wireWoolObject;

    private void OnEnable()
    {
        wireWoolObject.SetActive(true);
        StartCoroutine(WaitAndBurn(2f));

    }

    IEnumerator WaitAndBurn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        wireWoolObject.SetActive(false);
    }
}
