using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLightingBolt : MonoBehaviour
{
    [SerializeField] GameObject boltPrefab;
    [SerializeField] Transform spawnPoint;
    MagneticElectricField magnetic;

    void Start()
    {
        magnetic = gameObject.GetComponent<MagneticElectricField>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(boltPrefab, spawnPoint.position, transform.rotation);

            //if (magnetic.EnergyAmount >= 0.3f)
            //{
            //    magnetic.EnergyAmount -= 0.3f;
            //    Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
            //    //Debug.Log("Bolt");
            //}
        }
    }
}
