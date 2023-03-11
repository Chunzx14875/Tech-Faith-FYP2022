using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPuzzleRotateTile : MonoBehaviour
{
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<CharacterController>() != null)
    //    {
    //        transform.Rotate(0f, 90f, 0f); // rotate the cube by 90 degrees around Y-axis
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (TutorialPuzzleManager.instance.BluePuzzleSolved != true)
        {
            if (other.GetComponent<CharacterController>() != null)
            {
                transform.Rotate(0f, 90f, 0f); // rotate the cube by 90 degrees around Y-axis
            }
        }
    }
}
