using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject Light;
    [SerializeField] bool isCharge;

    [Space(25)]
    [Header("AUDIO SOURCE")]
    public AudioSource generatorSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        particles.SetActive(false);
        Light.SetActive(false);

        StartCoroutine("audioUpdate");
    }


    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") && isCharge == false)
        {
            Debug.Log("Charge");

            //sOUND
            generatorSound.PlayOneShot(AudioManager.instance.powerUpGenerator);
            generatorSound.clip = AudioManager.instance.generatorActivate;
            generatorSound.loop = true;
            generatorSound.Play();

            gameObject.GetComponent<SphereCollider>().enabled = true;
            gameObject.tag = "Generator";
            particles.SetActive(true);
            Light.SetActive(true);
            isCharge = true;

            animator.SetBool("IsCharge", true);
        }
    }

    IEnumerator audioUpdate()
    {
        while (true)
        {
            generatorSound.volume = AudioManager.instance.sourceClip.volume;
            yield return null;
        }
    }
}
