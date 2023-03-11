 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorLogic : MonoBehaviour
{
    Animator anim;
    public List<int> sequence;
    public List<int> addedSeq;

    [Space(25)]
    [Header("DOOR")]
    [SerializeField] Transform doorLeft;
    [SerializeField] Transform doorRight;
    Vector3 doorLeftStartPos;
    Vector3 doorRightStartPos;

    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.SetBool("OpenDoor", false);

        //Reset Position
        doorLeftStartPos = doorLeft.transform.position;
        doorRightStartPos = doorRight.transform.position;
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
                    //Door will not open
                }

            }
        }
        else
        {
            correct = false;
            //Door will not open
        }

        if (correct)
        {
            //Door open

            doorLeft.DOMove(new Vector3(doorLeft.transform.position.x + 2, doorLeft.transform.position.y, doorLeft.transform.position.z), 2);
            doorRight.DOMove(new Vector3(doorRight.transform.position.x - 2, doorRight.transform.position.y, doorRight.transform.position.z), 2);

            doorLeft.DOLocalMoveX(2.5f, 2);
            doorRight.DOLocalMoveX(-2.5f, 2);
        }
        else
        {
            //anim.SetBool("OpenDoor", false);

            doorLeft.DOMove(new Vector3(doorLeftStartPos.x, doorLeftStartPos.y, doorLeftStartPos.z), 2);
            doorRight.DOMove(new Vector3(doorRightStartPos.x, doorRightStartPos.y, doorRightStartPos.z), 2);
        }
    }
}
