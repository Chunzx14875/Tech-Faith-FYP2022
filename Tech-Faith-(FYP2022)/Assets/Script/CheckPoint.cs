using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    //public GameObject checkedPoint;
    //[SerializeField] GameObject checkPointOriginal;
    [SerializeField] GameObject checkPointOriginalNew;


    //void Start()
    //{
    //    checkedPoint = checkPointOriginal;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(checkPointOriginalNew, transform.position, transform.rotation);
            Destroy(gameObject);

            //checkedPoint = checkPointOriginalNew;
        }
    }
}
