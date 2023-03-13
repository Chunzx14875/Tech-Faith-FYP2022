using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecDevice : MonoBehaviour
{
    [Header("MovingPlate")]
    private Animator animator;
    [SerializeField] private GameObject activeMP;
    private string currentState;

    const string MOVING_PLATE = "MovingPlateForm";

    void Start()
    {
        animator = activeMP.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt"))
        {
            ChangeAnimationState(MOVING_PLATE);
            //Debug.Log("Detect Bolt");
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