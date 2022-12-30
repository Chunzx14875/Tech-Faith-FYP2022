using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public AudioSource explodeSound;

    void Start()
    {
        explodeSound.PlayOneShot(AudioManager.instance.enemyExplode);
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        
    }
}
