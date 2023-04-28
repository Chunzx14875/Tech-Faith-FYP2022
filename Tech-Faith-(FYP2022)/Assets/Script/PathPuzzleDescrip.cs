using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PathPuzzleDescrip : MonoBehaviour
{
    [SerializeField] GameObject Textbox;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject PathSwitches;
    [SerializeField] GameObject ColourPath;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
        title.text = string.Empty;
        text.text = string.Empty;
        PathSwitches.SetActive(false);
        ColourPath.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Textbox.SetActive(true);
            title.text = "Path Puzzle";
            text.text = "- There are many colour switches for red, yellow, blue and green but only have one real switch for each colour.\n" + "\n" +
                "- Besides of follow the sequences on the puzzle door, player also must put the colour boxes to the real switches to open the puzzle door.\n" + "\n" +
                "- The colour paths may help you to find the way lead to real switches for each colour.";


            PathSwitches.SetActive(true);
            ColourPath.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Textbox.SetActive(false);
            title.text = string.Empty;
            text.text = string.Empty;
            PathSwitches.SetActive(false);
            ColourPath.SetActive(false);
        }
    }
}
