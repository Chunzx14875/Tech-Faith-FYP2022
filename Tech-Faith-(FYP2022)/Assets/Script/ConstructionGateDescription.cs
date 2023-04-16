using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConstructionGateDescription : MonoBehaviour
{
    [SerializeField] GameObject Textbox;
    //[SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
        //title.text = string.Empty;
        text.text = string.Empty;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Textbox.SetActive(true);
            //title.text = string.Empty;
            text.text = "You must open this gate in abandoned area";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Textbox.SetActive(false);
            //title.text = string.Empty;
            text.text = string.Empty;
        }
    }
}
