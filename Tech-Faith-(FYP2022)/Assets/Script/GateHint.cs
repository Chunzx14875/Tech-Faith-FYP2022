using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateHint : MonoBehaviour
{
    [SerializeField] GameObject Textbox;
    [SerializeField] TextMeshProUGUI Titletext;
    [SerializeField] TextMeshProUGUI Descriptiontext;
    bool NexttoGate = false;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
        Titletext.text = string.Empty;
        Descriptiontext.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NexttoGate && CollectKey.instance.hasKey)
        {
            Textbox.SetActive(false);
            Titletext.text = string.Empty;
            Descriptiontext.text = string.Empty;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(CollectKey.instance.hasKey)
            {
                NexttoGate = true;
                Textbox.SetActive(true);
                Titletext.text = "Abandoned area";
                Descriptiontext.text = "Press 'E' to open the door";
            }
            else
            {
                NexttoGate = true;
                Textbox.SetActive(true);
                Titletext.text = "Abandoned area";
                Descriptiontext.text = "You need find a key to open the door";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            NexttoGate = false;
            Textbox.SetActive(false);
            Titletext.text = string.Empty;
            Descriptiontext.text = string.Empty;
        }
    }
}
