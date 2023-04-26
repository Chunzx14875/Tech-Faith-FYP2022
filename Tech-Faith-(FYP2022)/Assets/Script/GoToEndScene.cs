using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEndScene : MonoBehaviour
{
    [SerializeField] int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(index);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
