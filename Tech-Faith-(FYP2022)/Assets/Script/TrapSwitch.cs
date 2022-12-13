using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSwitch : MonoBehaviour
{
    [SerializeField] GameObject Trap;

    // Start is called before the first frame update
    void Start()
    {

            Trap.SetActive(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ElectricField")
        {
            Debug.Log("Switch Destroyed");
            Trap.SetActive(false);
        }
        
    }
}
