using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : DigitalClock
{
    [SerializeField] Transform minutesPointer;
    [SerializeField] Transform secondsPointer;

    int newSeconds = 0;
    int newMinutes = 0;

    protected override void Start()
    {
        base.Start();
    }

    protected override void CountTime()
    {
        CalculateRotations();
        RotatePointers();
    }

    void CalculateRotations()
    {
        newSeconds = seconds % 60;
        newMinutes = seconds / 60;
        Debug.Log(newMinutes + " : " + newSeconds);
    }

    void RotatePointers()
    {
        secondsPointer.localEulerAngles = new Vector3(0, 0, newSeconds * 6);
        minutesPointer.localEulerAngles = new Vector3(0, 0, newMinutes * 6);
        //secondsPointer.rotation.x = newSeconds *6;
        //minutesPointer.rotation.x = newMinutes *6;
    }
}
