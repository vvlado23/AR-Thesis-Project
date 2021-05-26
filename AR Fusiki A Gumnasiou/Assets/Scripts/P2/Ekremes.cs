using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ekremes : MonoBehaviour
{
    [SerializeField] AnalogClock analogClock;
    [SerializeField] DigitalClock digitalClock;

    Animator anim;
    bool isMoving = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }



    public void StartAnimation()
    {
        isMoving = true;
        anim.SetBool("IsMoving", isMoving);
        analogClock.StartTime();
        digitalClock.StartTime();

    }

    public void StopAnimation()
    {
        isMoving = false;
        anim.SetBool("IsMoving", isMoving);
        analogClock.StopTime();
        digitalClock.StopTime();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!isMoving)
            {
                StartAnimation();
            }            
        }
    }


}
