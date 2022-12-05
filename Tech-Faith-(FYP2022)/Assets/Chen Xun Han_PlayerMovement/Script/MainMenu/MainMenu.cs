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

    #region Buttons
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
    }
    #endregion

    #region SelectLevel
    public void tutorialLevel()
    {
        //SceneManager.LoadScene("Sample Layout");
        DOTween.KillAll();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void level1()
    {
        DOTween.KillAll();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Sample Layout");
    }

    public void level2()
    {
        DOTween.KillAll();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Sample Layout");
    }

    public void level3()
    {
        DOTween.KillAll();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Sample Layout");
    }
    #endregion

    #region Setting
    //public void sound()
    //{
    //}
    #endregion
}