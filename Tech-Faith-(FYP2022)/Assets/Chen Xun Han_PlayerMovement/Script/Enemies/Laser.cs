using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float launchForce;
    [SerializeField] float destroyAfterSec;
    Rigidbody rb;
    Transform targetPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPlayer = GameObject.FindGameObjectWithTag("Aim").transform;
        rb.transform.LookAt(targetPlayer);
        rb.velocity = transform.forward * launchForce;
    }


    void Update()
    {
        Destroy(gameObject, destroyAfterSec);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.tag == "Enemy"))
        {
            if(!(collision.gameObject.tag == "Damage"))
            {
                Destroy(gameObject);
                //Debug.Log("Laser destroy");
            }
        }
    }
}
