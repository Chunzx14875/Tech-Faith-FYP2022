using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLaserTrap : MonoBehaviour
{
    [Header("Laser Trap")]
    //[SerializeField] GameObject laserTrap;
    //[SerializeField] GameObject elecDevice;

    private Animator animator;
    private string currentState;

    const string TRAP_DOOR = "Trapdoor";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeAnimationState(TRAP_DOOR);
            //Debug.Log("Detect Player");
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
