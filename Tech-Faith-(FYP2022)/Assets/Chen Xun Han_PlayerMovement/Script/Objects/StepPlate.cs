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

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            doorRight.DOLocalMove(new Vector3(-2, 1.5f, 0), 1);
            doorLeft.DOLocalMove(new Vector3(2, 1.5f, 0), 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            doorRight.DOLocalMove(new Vector3(-0.71f, 1.5f, 0), 1);
            doorLeft.DOLocalMove(new Vector3(0.71f, 1.5f, 0), 1);
        }
    }
}
