using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneKnockBack : MonoBehaviour
{
    Rigidbody rb;
    private float KnockBackForce = -5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ElectricField")
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            Vector3 direction = (other.transform.position - transform.position).normalized;

            //if (direction.y <= 0)
            //{
            //    direction.y *= -0.75f;
            //}

            rb.AddForce(direction * KnockBackForce, ForceMode.Impulse);
        }
    }
}
