using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation1_1 : MonoBehaviour
{
    Player1_1 pController;
    Animator anim;

    private void Start()
    {
        pController = GetComponentInParent<Player1_1>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ChooseAnimation();
    }

    void ChooseAnimation()
    {
        anim.SetBool("Moving", pController.isMoving);
    }
}
