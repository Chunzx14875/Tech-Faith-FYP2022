using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackAndDestroy : MonoBehaviour
{
    [SerializeField] private float KnockBackForce = -50;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ElectricField")
        {
            Rigidbody childRigid = other.gameObject.GetComponentInChildren<Rigidbody>();

            Vector3 direction = (other.transform.position - transform.position).normalized;
            direction.y = -KnockBackForce;

            childRigid.AddForce(direction * KnockBackForce, ForceMode.Impulse);

            Destroy(gameObject, 1.5f);

            Debug.Log("Touch Eletric Field");
        }
    }
}
