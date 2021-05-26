using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] Transform rod;
    [SerializeField] Transform plateR;
    [SerializeField] Transform plateL;

    float scaleRotation=0;//scale from -0.4(left) to 0.4(right)

    private void RotateRod()
    {
        rod.localRotation = new Quaternion(0, 0, scaleRotation, 1);
        plateR.localRotation = new Quaternion(0, 0, -scaleRotation, 1);
        plateL.localRotation = new Quaternion(0, 0, -scaleRotation, 1);
    }

    public void AddWeight(float weight)
    {
        scaleRotation += weight;
        RotateRod();
    }
}
