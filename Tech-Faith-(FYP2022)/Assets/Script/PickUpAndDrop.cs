using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
    [Header("Pick up")]
    [Space(1)]
    [SerializeField] private Transform HoldArea;
    [SerializeField] private Transform RaycastFrom;
    GameObject heldObj;
    Rigidbody heldObjRB;
    [Space(5)]

    [Header("Physics Parameters")]
    [Space(1)]
    [SerializeField] private float pickUpRange = 2f;
    [SerializeField] private float pickUpForce = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(RaycastFrom.transform.position, transform.forward, out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.CompareTag("CanPick"))
                    {
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObj != null)
        {
            MoveObject();
        }

        Debug.DrawRay(transform.position, transform.forward * pickUpRange, Color.green);
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, HoldArea.position) > 0.05f)
        {
            Vector3 moveDirection = (HoldArea.position - heldObj.transform.position);

            heldObjRB.AddForce(moveDirection * pickUpForce);
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            //heldObjRB.mass = 0;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = HoldArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 0;
        //heldObjRB.mass = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;
    }
}
