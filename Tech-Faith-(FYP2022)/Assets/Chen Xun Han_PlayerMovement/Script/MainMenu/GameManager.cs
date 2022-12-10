using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("AUDIO SOURCE")]
    public AudioSource bgmSoundG;
    public AudioSource sourceClipG;


    private void Awake()
    {
        //if we dont have game manager in scene then transfer the game manager to next scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else//but if we have one in scene just destroy it to avoid have 2 game manager in scene
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        bgmSoundG.volume = AudioManager.instance.bgmSound.volume;
        sourceClipG.volume = AudioManager.instance.sourceClip.volume;
    }
}
