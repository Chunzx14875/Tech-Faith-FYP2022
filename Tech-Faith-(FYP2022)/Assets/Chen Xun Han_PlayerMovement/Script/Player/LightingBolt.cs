using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBolt : MonoBehaviour
{
    [SerializeField] float destroyAfterSec;

    void Start()
    {

    }

    void Update()
    {
        Destroy(gameObject, destroyAfterSec);
    }
}
