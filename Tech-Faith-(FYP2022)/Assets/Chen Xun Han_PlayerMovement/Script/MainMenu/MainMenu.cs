using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [Header("CAMERA")]
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform targetCamera;
    //[SerializeField] float smoothSpeed = 0.125f;
    //public Vector3 offset;
    [SerializeField] Transform targetMain;
    [SerializeField] Transform targetStart;
    [SerializeField] Transform targetSetting;
    [SerializeField] Transform targetQuit;

    [Header("MAIN")]
    [Space(25)]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject settingMenu;

    [Header("START")]
    [Space(25)]
    [SerializeField] GameObject comfirmButton;

    [Header("SETTING")]
    [Space(25)]
    [SerializeField] GameObject settingenu;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void startButton()
    {
        startMenu.SetActive(true);
        mainMenu.SetActive(false);

        targetCamera.DOMove(targetStart.transform.position, 1);
        targetCamera.DORotateQuaternion(targetStart.transform.rotation, 1);
    }

    public void settingButton()
    {
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);

        targetCamera.DOMove(targetSetting.transform.position, 1);
        targetCamera.DORotateQuaternion(targetSetting.transform.rotation, 1);
    }

    public void quitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void backButton()
    {
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
        settingMenu.SetActive(false);

        targetCamera.DOMove(targetMain.transform.position, 1);
        targetCamera.DORotate(targetMain.transform.position, 1);
        //animationTrans();
    }

    //public void animationTrans()
    //{
    //    Vector3 desiredPos = target.position + offset;
    //    Vector3 smoothedPos = Vector3.Lerp(mainCamera.transform.position, desiredPos, smoothSpeed);
    //    mainCamera.transform.position = smoothedPos;

    //    mainCamera.transform.LookAt(target);
    //}


    #region SelectLevel
    public void tutorialLevel()
    {
        SceneManager.LoadScene("Sample Layout");
    }

    public void level1()
    {
        SceneManager.LoadScene("Sample Layout");
    }

    public void level2()
    {
        SceneManager.LoadScene("Sample Layout");
    }

    public void level3()
    {
        SceneManager.LoadScene("Sample Layout");
    }
    #endregion

    #region Setting
    //public void sound()
    //{
    //}
    #endregion
}
