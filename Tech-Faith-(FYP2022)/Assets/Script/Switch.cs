using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool TouchBox;

    // Start is called before the first frame update
    void Start()
    {
        TouchBox = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Grey Box")
        {
            TouchBox = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Grey Box")
        {
            TouchBox = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Grey Box")
        {
            TouchBox = false;
        }
    }
}
