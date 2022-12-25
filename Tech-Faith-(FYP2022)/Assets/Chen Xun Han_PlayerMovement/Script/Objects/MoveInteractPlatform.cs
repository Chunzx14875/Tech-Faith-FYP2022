using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveInteractPlatform : MonoBehaviour
{
    [SerializeField] Transform[] pos;
    [SerializeField] float objectSpeed;
    int nextPosIndex;
    Transform nextPos;

    [SerializeField] private Transform movePosition;
    [SerializeField] private Transform orignalPosition;
    [SerializeField] private float cycleLength;
    [SerializeField] private bool isStun;

    void Start()
    {
        //transform.DOMove(movePosition.position, cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        nextPos = pos[0];
        StartCoroutine("movePlatform");
    }


    void Update()
    {
        if (isStun == false)
        {
            if (transform.position == nextPos.position)
            {
                nextPosIndex++;

                if (nextPosIndex >= pos.Length)
                {
                    nextPosIndex = 0;
                }
                nextPos = pos[nextPosIndex];
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos.position, objectSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt") && isStun == false)
        {
            isStun = true;
            //transform.DOMove(movePosition.position, cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            //transform.DOMove(orignalPosition.position, cycleLength).SetEase(Ease.InOutSine);
            Debug.Log("Stun");

            //if (transform.position == movePosition.position)
            //{
            //   // transform.DOMove(movePosition.position, cycleLength).SetEase(Ease.InOutSine);
            //    transform.DOMove(orignalPosition.position, cycleLength).SetEase(Ease.InOutSine);
            //}
            //else if (transform.position == orignalPosition.position)
            //{
            //    //transform.DOMove(orignalPosition.position, cycleLength).SetEase(Ease.InOutSine);
            //    transform.DOMove(movePosition.position, cycleLength).SetEase(Ease.InOutSine);
            //}
        }
        else if (other.CompareTag("Bolt") && isStun == true)
        {
            isStun = false;
            //transform.DOMove(Vector3.zero, 0);
            //DOTween.Kill(transform);
            Debug.Log("Move");
        }
        else if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            Debug.Log("Player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    IEnumerator movePlatform()
    {
        //transform.DOMove(movePosition.position, cycleLength).SetEase(Ease.InOutSine);
        //transform.DOMove(orignalPosition.position, cycleLength).SetEase(Ease.InOutSine);
        //yield return null;

        //while (true)
        //{
        //    if (isStun == false)
        //    {
        //        transform.DOMove(movePosition.position, cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        //    }
        //    else
        //    {
        //        transform.DOMove(Vector3.zero, 0);
        //    }

        //    yield return null;
        //}

        if (transform.position == nextPos.position)
        {
            nextPosIndex++;

            if (nextPosIndex >= pos.Length)
            {
                nextPosIndex = 0;
            }
            nextPos = pos[nextPosIndex];
            //yield return new WaitForSeconds(3);
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, nextPos.position, objectSpeed * Time.deltaTime);
            transform.DOMove(nextPos.position, cycleLength).SetEase(Ease.InOutSine);
            //yield return new WaitForSeconds(3);
        }

        //yield return new WaitForSeconds(3);
        yield return null;
    }
}
