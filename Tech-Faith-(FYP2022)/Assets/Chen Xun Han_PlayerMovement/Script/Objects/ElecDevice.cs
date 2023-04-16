using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecDevice : MonoBehaviour
{
    [Header("MovingPlate")]
    private Animator animator;
    [SerializeField] private GameObject activeMP;
    [SerializeField] private GameObject ps;
    private string currentState;

    const string MOVING_PLATE = "MovingPlateForm";

    void Start()
    {
        animator = activeMP.GetComponent<Animator>();
        ps.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt"))
        {
            ChangeAnimationState(MOVING_PLATE);
            ps.SetActive(true);
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
