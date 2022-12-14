using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AUDIO SOURCE")]
    public AudioSource bgmSound;
    public AudioSource sourceClip;
    public Slider sliderBgm;
    public Slider sliderClip;

    [Space(25)]
    [Header("BUTTON CLICK")]
    public AudioClip buttonClick;
    public AudioClip buttonBack;
    public AudioClip buttonTrans;

    [Space(25)]
    [Header("PLAYER")]
    public AudioClip pauseMenu;
    public AudioClip playerExplode;
    public AudioClip electricField;
    public AudioClip electricBolt;
    public AudioClip shieldBreak;

    [Space(25)]
    [Header("ENEMY")]
    public AudioClip laserClip;
    public AudioClip paralyzed;
    public AudioClip enemyExplode;

    [Space(25)]
    [Header("OBJECTS")]
    public AudioClip powerUpGenerator;
    public AudioClip generatorActivate;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (instance == null)
        {
            instance = this;
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        //DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        bgmSound.volume = GameManager.instance.bgmSoundG.volume;
        sourceClip.volume = GameManager.instance.sourceClipG.volume;

        sliderBgm.value = bgmSound.volume;
        sliderClip.value = sourceClip.volume;
    }

    public void SliderBgm()
    {
        bgmSound.volume = sliderBgm.value;
    }

    public void SliderSFX()
    {
       sourceClip.volume = sliderClip.value;
    }

    #region Buttons Sound
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
    #endregion

    #region Player Sound
    public void pauseMenuSound(AudioClip pauseMenu)
    {
        sourceClip.PlayOneShot(pauseMenu);
    }

    public void playerExplodeSound(AudioClip playerExplode)
    {
        sourceClip.PlayOneShot(playerExplode);
    }

    public void electricFieldSound(AudioClip electricField)
    {
        sourceClip.PlayOneShot(electricField);
    }

    public void electricBoltSound(AudioClip electricBolt)
    {
        sourceClip.PlayOneShot(electricBolt);
    }

    public void shieldBreakSound(AudioClip shieldBreak)
    {
        sourceClip.PlayOneShot(shieldBreak);
    }

    #endregion

    #region Enemies Sound
    public void laserClipSound(AudioClip laserClip)
    {
        sourceClip.PlayOneShot(laserClip);
    }

    public void paralyzedSound(AudioClip paralyzed)
    {
        sourceClip.PlayOneShot(paralyzed);
    }
    #endregion
}
