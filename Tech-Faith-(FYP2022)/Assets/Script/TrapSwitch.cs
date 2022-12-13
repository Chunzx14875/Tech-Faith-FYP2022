using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float KnockBackForce = -50;

    [SerializeField] GameObject Traps;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ElectricField")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            direction.y = -KnockBackForce;

            rb.AddForce(direction * KnockBackForce, ForceMode.Impulse);

            Destroy(Traps);
        }
    }
}
