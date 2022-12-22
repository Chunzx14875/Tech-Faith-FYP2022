using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLightingBolt : MonoBehaviour
{
    [SerializeField] GameObject boltPrefab;
    [SerializeField] Transform spawnPoint;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
            Debug.Log("Bolt");
        }
    }
}
