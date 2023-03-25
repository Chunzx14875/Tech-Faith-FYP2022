using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch : MonoBehaviour
{
    [Header("Trap")]
    [SerializeField] GameObject Trap;

    Rigidbody rb;
    [SerializeField] private float KnockBackForce = -50;

    [Space(25)]
    [Header("MovingPlate")]
    private Animator animator;
    [SerializeField] private GameObject activeElecDevice;
    private string currentState;

    const string ELEC_DEVICE = "Smallplate";

    void Start()
    {
        animator = activeElecDevice.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "ElectricField")
        //{
        //    Vector3 direction = (other.transform.position - transform.position).normalized;
        //    direction.y = -KnockBackForce;

        //    rb.AddForce(direction * KnockBackForce, ForceMode.Impulse);

        //    Destroy(Trap);

        //    Debug.Log("destroy");

        //}

        if (other.tag == "Bolt")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            direction.y = -KnockBackForce;

            rb.AddForce(direction * KnockBackForce, ForceMode.Impulse);

            Destroy(Trap);
            Debug.Log("destroy");

            ChangeAnimationState(ELEC_DEVICE);
        }
    }

    void ChangeAnimationState(string newState)
    {
        //Stop the same animation from interrupting itself
        if (currentState == newState) return;

        //Play the animation
        animator.Play(newState);

        //Reassign the current state
        currentState = newState;
    }
}
