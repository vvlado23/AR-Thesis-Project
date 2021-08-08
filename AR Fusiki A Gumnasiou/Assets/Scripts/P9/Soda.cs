using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Soda : MonoBehaviour
{
    [SerializeField] GameObject straw;
    [SerializeField] GameObject smokeVFX;

    public void StartAnimation()
    {
        straw.SetActive(true);
        straw.GetComponent<DestroyAfterTime>().StartTimer();
        smokeVFX.SetActive(true);
    }
}
