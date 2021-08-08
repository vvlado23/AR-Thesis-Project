using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractP11 : Interactable
{
    [SerializeField] GameObject[] enableObjects;

    protected override void Interact()
    {
        foreach(GameObject obj in enableObjects)
        {
            obj.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
