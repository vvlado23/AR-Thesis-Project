using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : DigitalClock
{
    [SerializeField] Transform minutesPointer;
    [SerializeField] Transform secondsPointer;

    protected override void Start()
    {
        base.Start();
    }

    protected override void CountTime()
    {
        CalculateMinSec();
        RotatePointers();
    }

    void RotatePointers()
    {
        secondsPointer.localEulerAngles = new Vector3(0, 0, newSeconds * 6);
        minutesPointer.localEulerAngles = new Vector3(0, 0, newMinutes * 6);
        //secondsPointer.rotation.x = newSeconds *6;
        //minutesPointer.rotation.x = newMinutes *6;
    }
}
