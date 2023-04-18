using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayToEveLevel1 : MonoBehaviour
{
    [SerializeField] private Animator DaytoEveAnim;

    // Start is called before the first frame update
    //void Start()
    //{
    //    DaytoEveAnim = GetComponent<Animator>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DaytoEveAnim.SetTrigger("DayToEve");
        }
    }
}
