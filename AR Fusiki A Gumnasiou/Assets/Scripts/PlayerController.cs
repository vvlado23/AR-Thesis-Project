using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent myAgent;
    [SerializeField] LayerMask whatIsInteractable;
    [SerializeField] Transform holdingPosition;

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
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, whatIsInteractable))
            {
                //TryMove(hit);
                TryInteract(hit);
            }
        }
    }

    void TryMove(Vector3 hit)
    {
        myAgent.SetDestination(hit);
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
        }
    }

    void PickUpItem(Transform item)
    {
        if (holdingPosition.childCount > 0)
        {
            return;
        }
        item.parent.SetParent(holdingPosition);
        item.parent.localPosition = Vector3.zero;
        item.parent.localRotation = Quaternion.Euler(0, 0, 0);//set rotation and position of item's parent to holdingPosition
        isHolding = true;
    }

    GameObject PutDownItem()
    {
        if(holdingPosition.childCount==0)
        {
            return null;
        }
        isHolding = false;
        return holdingPosition.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            PickUpItem(other.transform);
        } 
    }
}
