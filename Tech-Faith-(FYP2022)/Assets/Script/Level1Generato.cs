using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Generato : MonoBehaviour
{
    public bool TouchBox;

    [Space(25)]
    [Header("DOOR")]
    [SerializeField] GameObject ConstrutionGate;

    // Start is called before the first frame update
    void Start()
    {
        TouchBox = false;

        //Reset
        ConstrutionGate.SetActive(true);
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.name == "Grey Box")
    //    {
    //        TouchBox = true;
    //    }
    //}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Grey Box")
        {
            TouchBox = true;

            ConstrutionGate.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Grey Box")
        {
            TouchBox = false;

            ConstrutionGate.SetActive(true);
        }
    }
}
