using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("MAIN")]
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
    }

    public void settingButton()
    {
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
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
    }


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
