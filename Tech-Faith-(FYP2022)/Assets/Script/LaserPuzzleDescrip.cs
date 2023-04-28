using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaserPuzzleDescrip : MonoBehaviour
{
    [SerializeField] GameObject Textbox;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject LaserImage;
    [SerializeField] GameObject BoxImage;
    [SerializeField] GameObject MirrorImage;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
        title.text = string.Empty;
        text.text = string.Empty;
        LaserImage.SetActive(false);
        BoxImage.SetActive(false);
        MirrorImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Textbox.SetActive(true);
            title.text = "Laser Puzzle";
            text.text = "- Player need make the colour laser shoot on the corresponding colour image on the wall to get the colour box. " +
                "(eg : Blue laser must shoot to the blue box image to get blue box.)\n" + "\n" +
                "- Player can pick the colour mirror and put on the way of laser to reflect the laser. Mirror only can reflect the same colour laser. (eg : Blue mirror only can reflect the blue laser.)";
            

            LaserImage.SetActive(true);
            BoxImage.SetActive(true);
            MirrorImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Textbox.SetActive(false);
            title.text = string.Empty;
            text.text = string.Empty;
            LaserImage.SetActive(false);
            BoxImage.SetActive(false);
            MirrorImage.SetActive(false);
        }
    }
}
