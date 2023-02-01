using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Switch : MonoBehaviour
{
    public bool TouchBox;

    [Space(25)]
    [Header("DOOR")]
    [SerializeField] Transform doorLeft;
    [SerializeField] Transform doorRight;
    Vector3 doorLeftStartPos;
    Vector3 doorRightStartPos;

    // Start is called before the first frame update
    void Start()
    {
        TouchBox = false;

        //Reset
        doorLeftStartPos = doorLeft.transform.position;
        doorRightStartPos = doorRight.transform.position;
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

            doorLeft.DOLocalMoveX(2.5f, 2);
            doorRight.DOLocalMoveX(-2.5f, 2);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Grey Box")
        {
            TouchBox = false;

            doorLeft.DOMove(new Vector3(doorLeftStartPos.x, doorLeftStartPos.y, doorLeftStartPos.z), 2);
            doorRight.DOMove(new Vector3(doorRightStartPos.x, doorRightStartPos.y, doorRightStartPos.z), 2);
        }
    }
}
