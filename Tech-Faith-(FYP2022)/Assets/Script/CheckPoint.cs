using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Light ligthColor;
    [SerializeField] ParticleSystem EffectColor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ligthColor.color = Color.green;
            EffectColor.startColor = Color.green;
        }
    }
}
