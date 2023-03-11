using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRedPuzzleTile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (TutorialPuzzleManager.instance.RedPuzzleSolved != true)
        {
            if (other.GetComponent<CharacterController>() != null)
            {
                transform.Rotate(0f, 90f, 0f); // rotate the cube by 90 degrees around Y-axis
            }
        }
    }
}
