using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerP7_3 : MonoBehaviour
{
    [SerializeField] GlassWithIceLayers liquid;
    public bool frozen = false;
    Animator anim;

    public void AddIceCube()
    {
        frozen = true;
        anim = GetComponent<Animator>();
        anim.Play("Freezer Open P7_3");
        StartCoroutine(FinishAnimationThenSpawnIceCubes(2f));
    }

    IEnumerator FinishAnimationThenSpawnIceCubes(float time)
    {
        yield return new WaitForSeconds(time);
        liquid.SetTemperture();
    }
}
