using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSpin : MonoBehaviour
{
    bool allEnable = false;
    [SerializeField] Transform wire;
    [SerializeField] float spinSpeed;

    private void Update()
    {
        CheckIfChildrenAreEnable();
        if (allEnable)
            Spin();
    }

    void Spin()
    {
        wire.Rotate(spinSpeed * Time.deltaTime, 0, 0, Space.Self);
    }

    void CheckIfChildrenAreEnable()
    {
        bool allChildrenEnable = true;
        foreach(Transform child in transform)
        {
            if(child.gameObject.activeSelf)
            {
                allChildrenEnable = true;
            }
            else
            {
                allChildrenEnable = false;
                break;
            }
        }
        allEnable = allChildrenEnable;
    }
}
