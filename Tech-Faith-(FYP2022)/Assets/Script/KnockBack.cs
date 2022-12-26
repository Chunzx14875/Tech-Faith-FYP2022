using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float KnockBackForce = -50;

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
        }
        if (other.tag == "Respawn")
        {
            StartCoroutine(MassIncrease());
        }
    }

    IEnumerator MassIncrease()
    {
        rb.drag = 100f;

        yield return new WaitForSeconds(0.5f);

        rb.drag = 0f;

    }
}
