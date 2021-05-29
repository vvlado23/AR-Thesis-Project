using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent myAgent;
    [SerializeField] LayerMask whatIsInteractable;
    [SerializeField] Transform holdingPosition;

    [Header("DEBUG")]
    public Vector3 vel = new Vector3();
    public bool isHolding = false;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckIfTouch();
        vel = myAgent.velocity;
    }


    void CheckIfTouch()
    {
        if(vel.sqrMagnitude>0)
        {
            return;
        }
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if(CheckIfTouchUI()) { return; }
            
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, whatIsInteractable))
            {
                TryInteract(hit);
            }
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

    void TryInteract(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Interactable"))
        {
            TryMove(hit.transform.parent.position);
            //PickUpItem(hit.transform);
        }else if(hit.transform.CompareTag("Ground"))
        {
            TryMove(hit.point);
        }else if(hit.transform.CompareTag("Pick up"))
        {
            TryMove(hit.point);
        }
    }

    void TryMove(Vector3 hit)
    {
        myAgent.SetDestination(hit);
    }

    public void PickUpItem(Transform item)
    {
        if (holdingPosition.childCount > 0)
        {
            return;
        }
        item.SetParent(holdingPosition);
        item.localPosition = Vector3.zero;
        item.localRotation = Quaternion.Euler(0, 0, 0);//set rotation and position of item's parent to holdingPosition
        isHolding = true;
    }

    public void PutDownButton()
    {
        if (holdingPosition.childCount == 0)
            return;
        Vector3 newPosition = holdingPosition.transform.position;
        PutDownItem(transform.parent, newPosition);
    }

    public GameObject PutDownItem(Transform newParent, Vector3 newPosition)
    {
        if(holdingPosition.childCount==0)
        {
            return null;
        }
        isHolding = false;
        GameObject item = holdingPosition.transform.GetChild(0).gameObject;
        item.transform.SetParent(newParent);
        item.transform.position = newPosition;
        return item;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            PickUpItem(other.transform.parent);
        }
    }
}
