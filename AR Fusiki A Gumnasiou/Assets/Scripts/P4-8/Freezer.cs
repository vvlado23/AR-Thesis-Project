using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    [SerializeField] LiquidTemperture liquid;
    [SerializeField] float tempertureChangeRate=5f;
    Animator anim;

    public void AddIceCube()
    {
        anim = GetComponent<Animator>();
        anim.Play("Freezer Open");
        if(liquid.GetComponent<LiquidWithIce>())
        {
            StartCoroutine(FinishAnimationThenSpawnIceCubes(2f));
        }
        liquid.CoolDown(0, tempertureChangeRate);
    }

    IEnumerator FinishAnimationThenSpawnIceCubes(float time)
    {
        yield return new WaitForSeconds(time);

        liquid.GetComponent<LiquidWithIce>().AddIceCubes();
    }
}
