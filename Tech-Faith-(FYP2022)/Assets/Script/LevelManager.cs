using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelUnlocked;

    public GameObject confirm;
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < levelUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void ResetLevel()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != buttons[0])
            {
                buttons[i].interactable = false;
            }
        }

        PlayerPrefs.DeleteAll();
        confirm.SetActive(false);

    }

    public void GoHome()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void Panel()
    {
        confirm.SetActive(true);
    }

    public void ClosePanel()
    {
        confirm.SetActive(false);
    }

}
