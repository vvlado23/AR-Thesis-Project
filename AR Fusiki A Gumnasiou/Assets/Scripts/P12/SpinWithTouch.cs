using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpinWithTouch : MonoBehaviour
{
    [SerializeField] Material lampOff;
    [SerializeField] Material lampOnFull;
    [SerializeField] Material lampOn2;
    [SerializeField] MeshRenderer lamp;
    bool isTouching = false;

    [Header("DEBUG")]
    public Vector2 objPos;
    public Vector2 prevTouchPosition=Vector2.zero;
    public Vector2 touchPosition;
    public Vector2 touchRotation;

    public float rotateSpeed;

    void FixedUpdate()
    {
        CheckStartTouch();
        CheckTouching();
        CheckFinishTouch();
        RotateObject();
    }

    void CheckStartTouch()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (CheckIfTouchUI()) { return; }

            isTouching = true;

            touchPosition = Input.touches[0].position;
        }
    }

    void CheckTouching()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            isTouching = true;
            touchPosition = Input.touches[0].position;

            rotateSpeed = (prevTouchPosition - touchPosition).magnitude;
            TurnOnLamp();
            
            prevTouchPosition = touchPosition;

            objPos = Camera.main.WorldToScreenPoint(transform.position);
            touchRotation = (touchPosition - objPos).normalized;
        }
    }

    void TurnOnLamp()
    {
        if (rotateSpeed <= 0)
        {

        }
        else if (rotateSpeed > 200)
        {
            lamp.material = lampOnFull;
        }
        else
        {
            lamp.material = lampOn2;
        }
    }

    void CheckFinishTouch()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            isTouching = false;
            TurnOffLamp();
        }
    }


    bool CheckIfTouchUI()
    {
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                return true;
            }
        }
        return false;
    }

    void RotateObject()
    {
        float angle = Mathf.Atan2(touchRotation.y, touchRotation.x) * Mathf.Rad2Deg - 90;
        transform.localRotation= Quaternion.AngleAxis(angle, Vector3.down);
    }

    

    void TurnOffLamp()
    {
        lamp.material = lampOff;
    }
}
