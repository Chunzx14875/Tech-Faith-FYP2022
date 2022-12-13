using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] float rotatespeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotatespeed * Time.deltaTime, 0f, 0f);
    }
}
