using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawn : MonoBehaviour
{
    Vector3 respawnPoint;
    //[SerializeField] private GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        Debug.Log(respawnPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            transform.position = respawnPoint;
        }
    }
}
