using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour
{
    Animator anim;

    [SerializeField] private Switch isSwitchOn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("OpenDoor", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwitchOn.TouchBox)
        {
            anim.SetBool("OpenDoor", true);
        }
        else
        {
            anim.SetBool("OpenDoor", false);
        }
    }
}
