using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintBox : MonoBehaviour
{
    public static HintBox instance;
    public GameObject TextBox;
    public Text hintText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TextBox.SetActive(false);
        hintText.text = "";
    }

}