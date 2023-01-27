using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarFaceToCam : MonoBehaviour
{
    [SerializeField] Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
    }

    //void LateUpdate()
    //{
    //    transform.LookAt(cam);        
    //}
}
