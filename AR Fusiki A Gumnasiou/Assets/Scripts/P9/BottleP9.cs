using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleP9 : Interactable
{
    [SerializeField] GameObject newBottle;
    [SerializeField] GlassP9 glass;

    protected override void Interact()
    {
        glass.AddBottle();
        newBottle.SetActive(true);
        newBottle.GetComponent<Animator>().SetTrigger("Start");
        newBottle.GetComponent<DestroyAfterTime>().StartTimer();
        Destroy(this.gameObject);
    }
}
