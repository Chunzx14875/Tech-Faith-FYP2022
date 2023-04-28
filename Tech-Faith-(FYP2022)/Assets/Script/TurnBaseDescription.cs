using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnBaseDescription : MonoBehaviour
{
    [SerializeField] GameObject Textbox;
    [SerializeField] GameObject Image;
    //[SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
        Image.SetActive(false);
        //title.text = string.Empty;
        text.text = string.Empty;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Textbox.SetActive(true);
            Image.SetActive(true);
            //title.text = "Based";
            text.text = "You can use the tools shown at right to help go to the opposite road.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Textbox.SetActive(false);
            Image.SetActive(false);
            //title.text = string.Empty;
            text.text = string.Empty;
        }
    }
}
