using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    Rigidbody rb;
    private float KnockBackForce = -25;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ElectricField")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;

            if (direction.y <= 0)
            {
                direction.y *= -0.75f;
            }

            rb.AddForce(direction * KnockBackForce, ForceMode.Impulse);
        }
    }
}
