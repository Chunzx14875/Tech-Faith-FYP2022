using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialDescription : MonoBehaviour
{
    [SerializeField] GameObject Textbox;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.SetActive(false);
        title.text = string.Empty;
        text.text = string.Empty;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Tutorial1")
        {
            Textbox.SetActive(true);
            title.text = "Movement";
            text.text = "- Move: W,A,S,D\n" + "\n" + "- Jump: Space\n" + "\n" + "- Camera movement: Mouse" ;
        }
        if (other.name == "Tutorial2")
        {
            Textbox.SetActive(true);
            title.text = "Pick and drop";
            text.text = "- Pick / Drop object: Press <sprite=0> on keyboard\n" + "\n"+
                "- Try pick up the grey box and drop it to the lock plate to open the door.";
        }
        if (other.name == "Tutorial3")
        {
            Textbox.SetActive(true);
            title.text = "CheckPoint";
            text.text = "- New respawn location when fall into deep.";
        }
        if (other.name == "Tutorial4")
        {
            Textbox.SetActive(true);
            title.text = "Puzzle";
            text.text = "- Player need solve the puzzle to get the color boxes that can open puzzle door.\n" +"\n" +
                "- Player needs stand on the tiles on the ground to rotate it and make the pattern of all tiles are same as the pattern on the wall.\n" + "\n" +
                "- After solve the puzzle, the color boxes will spawn on the certain platform.";
        }
        if (other.name == "Tutorial5")
        {
            Textbox.SetActive(true);
            title.text = "Puzzle door";
            text.text = "- Player needs five color boxes to open the puzzle door.\n" + "\n" +
                "- Player needs put the color boxes on the corresponding color lock plate based on the sequences above the puzzle door. \n" + "\n" +
                "- The sequences is from left to right. (eg: blue -> green -> purple -> red -> yellow)";
        }
        if (other.name == "Tutorial6")
        {
            Textbox.SetActive(true);
            title.text = "Electric bolt";
            text.text =  "- Shoot electric bolt at the console panel at the left side to disable the laser trap.";
        }
        if (other.name == "Tutorial7")
        {
            Textbox.SetActive(true);
            title.text = "Electric bolt";
            text.text = "- Shoot an electric bolt again at the electronic device at the left side to activate the floating platform.\n";
        }
        if (other.name == "Tutorial8")
        {
            Textbox.SetActive(true);
            title.text = "Generator";
            text.text = "- Shoot an electric bolt at the generator to activate. \n" + "\n" +
                        "- Player can get closer to activated generator to charge the energy faster.\n" + "\n" +
                        "- Generator also can help recover the shield of player when fully charge.";
        }
        if (other.name == "Tutorial9")
        {
            Textbox.SetActive(true);
            title.text = "Electric field";
            text.text = "- Press left mouse button <sprite=1> to release electric field.\n " + "\n" +
                        "- Electric field can destroy enemy and it will spend all the electric energy.";
        }
        if (other.name == "Tutorial10")
        {
            Textbox.SetActive(true);
            title.text = "Destroy enemy";
            text.text = "- Try use electric field to defeat enemy.\n" + "\n" + "- Electric bolt can stun the enemy.";
        }
        if (other.name == "Tutorial11")
        {
            Textbox.SetActive(true);
            title.text = "Electric energy";
            text.text = "- There is a electric energy bar at the top left part of screen.\n" + "\n" +
                "- The electric energy will replenish at a slower interval in default.\n" + "\n" +
                "- Go ahead and see what it can do.";
        }
        if (other.name == "Tutorial12")
        {
            Textbox.SetActive(true);
            title.text = "Electric bolt";
            text.text = "- Press right mouse button <sprite=2> to shoot an electric bolt.\n " + "\n" +
                        "- It will spend some electric energy to activate it and it has cooldown time.";
        }
        if (other.name == "Tutorial13")
        {
            Textbox.SetActive(true);
            title.text = "Shields";
            text.text = "- Player has 3 shields that around himself as the game start.\n " + "\n" +
                        "- Shield can protect player from being hurted by enemy and trap.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Textbox.SetActive(false);
        title.text = string.Empty;
        text.text = string.Empty;
    }
}
