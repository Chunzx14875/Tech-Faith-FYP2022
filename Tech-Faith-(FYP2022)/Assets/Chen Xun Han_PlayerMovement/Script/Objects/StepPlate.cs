using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StepPlate : MonoBehaviour
{
    [Space(25)]
    [Header("DOOR")]
    [SerializeField] Transform doorLeft;
    [SerializeField] Transform doorRight;
    Vector3 doorLeftStartPos;
    Vector3 doorRightStartPos;

    void Start()
    {
        //Reset Position
        doorLeftStartPos = doorLeft.transform.position;
        doorRightStartPos = doorRight.transform.position;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            doorLeft.DOMove(new Vector3(2, doorLeft.transform.position.y, doorLeft.transform.position.z), 2);
            doorRight.DOMove(new Vector3(-2, doorRight.transform.position.y, doorRight.transform.position.z), 2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            doorLeft.DOMove(new Vector3(doorLeftStartPos.x, doorLeftStartPos.y, doorLeftStartPos.z), 2);
            doorRight.DOMove(new Vector3(doorRightStartPos.x, doorRightStartPos.y, doorRightStartPos.z), 2);
            //doorRight.DOLocalMove(new Vector3(-1.7f, doorLeft.transform.position.y, 0), 1);
            //doorLeft.DOLocalMove(new Vector3(1.7f, doorRight.transform.position.y, 0), 1);
        }
    }
}
