using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    Animator anim;
    public List<int> sequence;
    public List<int> addedSeq;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("OpenDoor", false);
    }

    public void AddKey(int target)
    {
        addedSeq.Add(target);
        CheckKey();
    }

    void CheckKey()
    {
        bool correct = true;
        if (addedSeq.Count >= sequence.Count)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if(sequence[i] != addedSeq[i])
                {
                    correct = false;
                }

            }
        }
        else
        {
            correct = false;
        }

        if(correct)
        {
            anim.SetBool("OpenDoor", true);
        }
        else
        {
            anim.SetBool("OpenDoor", false);
        }
    }
}
