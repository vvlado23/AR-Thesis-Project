using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    PlayerController pController;
    Animator anim;

    private void Start()
    {
        pController = GetComponentInParent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ChooseAnimation();
    }

    void ChooseAnimation()
    {
        if(pController.vel!=Vector3.zero)
        {
            anim.SetBool("Moving",true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        if (pController.isHolding)
        {
            anim.SetBool("Holding", true);
        }
        else
        {
            anim.SetBool("Holding", false);
        }
    }
}
