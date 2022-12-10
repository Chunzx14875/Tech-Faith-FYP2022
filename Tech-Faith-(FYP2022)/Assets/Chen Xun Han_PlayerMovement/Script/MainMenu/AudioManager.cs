using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AUDIO SOURCE")]
    //public AudioSource bgmSound;
    [SerializeField] private AudioSource sourceClip;

    [Space(25)]
    [Header("BUTTON CLICK")]
    public AudioClip buttonClick;
    public AudioClip buttonBack;
    public AudioClip buttonTrans;

    [Space(25)]
    [Header("PLAYER")]
    public AudioClip pauseMenu;
    public AudioClip playerExplode;

    [Space(25)]
    [Header("ENEMY")]
    public AudioClip laserClip;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (instance == null)
        {
            instance = this;
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void buttonClickSound()
    {
        sourceClip.PlayOneShot(buttonClick);
    }

    public void buttonBackSound()
    {
        sourceClip.PlayOneShot(buttonBack);
    }

    public void buttonTransSound()
    {
        sourceClip.PlayOneShot(buttonTrans);
    }

    public void playerExplodeSound(AudioClip playerExplode)
    {
        sourceClip.PlayOneShot(playerExplode);
    }

    public void pauseMenuSound(AudioClip pauseMenu)
    {
        sourceClip.PlayOneShot(pauseMenu);
    }

    public void laserClipSound(AudioClip laserClip)
    {
        sourceClip.PlayOneShot(laserClip);
    }   
}
