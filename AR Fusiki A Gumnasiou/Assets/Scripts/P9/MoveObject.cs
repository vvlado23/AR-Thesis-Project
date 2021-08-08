using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveObject : Interactable
{
    [SerializeField] Transform newPosition;

    [Header("Events")]
    [Space]

    public UnityEvent OnInteract;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    protected override void Interact()
    {
        transform.position = newPosition.position;
        OnInteract.Invoke();
    }

}
