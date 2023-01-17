using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockNextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            int currentlevel = SceneManager.GetActiveScene().buildIndex;

            if (currentlevel >= PlayerPrefs.GetInt("levelUnlocked"))
            {
                PlayerPrefs.SetInt("levelUnlocked", currentlevel);
            }

            
        }
    }
}
