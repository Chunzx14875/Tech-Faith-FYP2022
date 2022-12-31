using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public static Explode instance;

    public AudioSource explodeSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        //else//but if we have one in scene just destroy it to avoid have 2 game manager in scene
        //{
        //    Destroy(gameObject);
        //}
    }

    void Start()
    {
        //StartCoroutine("audioUpdate");
        explodeSound.volume = AudioManager.instance.sourceClip.volume;

        explodeSound.PlayOneShot(AudioManager.instance.enemyExplode);
        Destroy(gameObject, 1f);
    }

    void Update()
    {

    }

    IEnumerator audioUpdate()
    {
        while (true)
        {
            explodeSound.volume = AudioManager.instance.sourceClip.volume;

            yield return null;
        }
    }
}
