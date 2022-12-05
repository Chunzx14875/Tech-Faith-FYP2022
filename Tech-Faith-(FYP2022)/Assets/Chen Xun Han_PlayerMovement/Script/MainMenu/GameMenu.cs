using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [Header("GAME MENU")]
    [SerializeField] GameObject option;
    [SerializeField] bool openOption = false;

    [Space(25)]
    [Header("CHASING")]
    [SerializeField] GameObject losePanel;
    public bool isLose;

    void Start()
    {
        
    }


    void Update()
    {
        if (!isLose)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && openOption == false)
            {
                AudioManager.instance.pauseMenuSound(AudioManager.instance.pauseMenu);
                option.SetActive(true);
                openOption = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && openOption == true)
            {
                AudioManager.instance.pauseMenuSound(AudioManager.instance.pauseMenu);
                option.SetActive(false);
                openOption = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1f;
            }
        }
    }


    public void ResetScene()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void losePanelOpen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        losePanel.SetActive(true);
        isLose = true;
    }
}
