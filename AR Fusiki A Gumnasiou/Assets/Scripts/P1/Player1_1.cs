using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_1 : MonoBehaviour
{
    [SerializeField] LayerMask whatIsInteractable;
    [SerializeField] float speed = 0.2f;

    public bool isMoving = false;

    Rigidbody rb;
    Vector3 hitPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckIfTouch();
    }

    private void FixedUpdate()
    {
        if(isMoving)
            TryMove();
    }

    void CheckIfTouch()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, whatIsInteractable))
            {
                Debug.Log(hit.collider.gameObject);
                MoveToHit(hit);
            }
        }
    }

    void MoveToHit(RaycastHit hit)
    {
        isMoving = true;
        hitPos = hit.point;
    }

    void TryMove()
    {
        Vector3 targetPos = new Vector3(hitPos.x, transform.position.y, hitPos.z);
        Vector3 relativePos = targetPos - transform.position;

        transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(transform.position == targetPos)
        {
            isMoving = false;
        }
    }
}
