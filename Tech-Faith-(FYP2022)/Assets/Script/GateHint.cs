using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GateHint : MonoBehaviour
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CollectKey.instance.hasKey)
        {
            Textbox.SetActive(false);
            //title.text = string.Empty;
            text.text = string.Empty;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(CollectKey.instance.hasKey)
            {
                Textbox.SetActive(true);
                //title.text = string.Empty;
                text.text = "Press 'E' to open the door";
            }
            else
            {
                Textbox.SetActive(true);
                //title.text = string.Empty;
                text.text = "You need find a key to open the door";
            }
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
