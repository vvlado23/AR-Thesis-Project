using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] GameObject frozenBottle;

    public void Freeze()
    {
        GameObject newBottle=Instantiate(frozenBottle,transform);
        newBottle.transform.localScale = transform.GetChild(0).localScale;
        Destroy(transform.GetChild(0).gameObject);
    }
}

