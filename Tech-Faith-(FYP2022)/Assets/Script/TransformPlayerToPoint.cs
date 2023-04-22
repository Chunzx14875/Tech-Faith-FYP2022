using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayerToPoint : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            transform.position = teleportDestination.position;
            Debug.Log("Touch Portal");
        }
    }
}
