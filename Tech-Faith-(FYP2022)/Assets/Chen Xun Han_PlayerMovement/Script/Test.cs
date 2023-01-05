using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(new Vector3(-7, 0, 0), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
