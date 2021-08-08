using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubesRotate : MonoBehaviour
{
    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed *Time.deltaTime, 0),Space.World);
    }
}
