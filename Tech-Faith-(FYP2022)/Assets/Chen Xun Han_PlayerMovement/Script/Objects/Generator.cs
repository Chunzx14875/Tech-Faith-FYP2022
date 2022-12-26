using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject particles;
    [SerializeField] bool isCharge;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") && isCharge == false)
        {
            Debug.Log("Charge");
            gameObject.GetComponent<SphereCollider>().enabled = true;
            gameObject.tag = "Generator";
            particles.SetActive(true);
            isCharge = true;
            animator.SetBool("IsCharge", true);
        }
    }
}
