using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTheBased : MonoBehaviour
{
    [Header("Physics Parameters")]
    [Space(1)]
    [SerializeField] private Transform RaycastFrom;
    [SerializeField] private float RaycastRange = 1f;
    [SerializeField] private bool detectSwitch = false;
    [SerializeField] private Animator anim;
    [SerializeField] GameObject Camera2;


    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //Based.SetBool("TurnOn", false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayhit;

        if (Physics.Raycast(RaycastFrom.transform.position, transform.forward, out rayhit, RaycastRange))
        {
            if (rayhit.transform.gameObject.CompareTag("Based"))
            {
                detectSwitch = true;
            }
            else
            {
                detectSwitch = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && detectSwitch)
        {
            Camera2.SetActive(true);
            anim.SetTrigger("TurnOn");
            Debug.Log("Switch on the turn Base.");

            if (rayhit.transform.gameObject.CompareTag("Based"))
            {
                rayhit.transform.gameObject.tag = "Untagged";
            }

            Invoke("DisableCamera", 8f);
        }
    }

    void DisableCamera()
    {
        Camera2.SetActive(false);
    }
}
