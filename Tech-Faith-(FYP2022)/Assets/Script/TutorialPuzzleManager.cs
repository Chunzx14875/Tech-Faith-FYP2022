using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialPuzzleManager : MonoBehaviour
{
    public static TutorialPuzzleManager instance;

    [Header("BluePuzzle")]
    [Space(10)]
    public bool BluePuzzleSolved = false;
    [SerializeField] Transform[] BluePuzzleTile;
    [SerializeField] GameObject BlueBox;
    [SerializeField] Transform SpawnBlueBox;
    bool spawnBlueBox = false;

    [Header("GreenPuzzle")]
    [Space(10)]
    public bool GreenPuzzleSolved = false;
    [SerializeField] Transform[] GreenPuzzleTile;
    [SerializeField] GameObject GreenBox;
    [SerializeField] Transform SpawnGreenBox;
    bool spawnGreenBox = false;

    [Header("PurplePuzzle")]
    [Space(10)]
    public bool PurplePuzzleSolved = false;
    [SerializeField] Transform[] PurplePuzzleTile;
    [SerializeField] GameObject PurpleBox;
    [SerializeField] Transform SpawnPurpleBox;
    bool spawnPurpleBox = false;

    [Header("RedPuzzle")]
    [Space(10)]
    public bool RedPuzzleSolved = false;
    [SerializeField] Transform[] RedPuzzleTile;
    [SerializeField] GameObject RedBox;
    [SerializeField] Transform SpawnRedBox;
    bool spawnRedBox = false;

    [Header("YellowPuzzle")]
    [Space(10)]
    public bool YellowPuzzleSolved = false;
    [SerializeField] Transform[] YellowPuzzleTile;
    [SerializeField] GameObject YellowBox;
    [SerializeField] Transform SpawnYellowBox;
    bool spawnYellowBox = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(BluePuzzleTile[0].rotation.y == 0 && BluePuzzleTile[1].rotation.y == 0 && BluePuzzleTile[2].rotation.y == 0 && BluePuzzleTile[3].rotation.y == 0)
        {
            BluePuzzleSolved = true;
            //Debug.Log("Blue Puzzle Solved!!!");

            if(!spawnBlueBox)
            {
                Instantiate(BlueBox, SpawnBlueBox.position, SpawnBlueBox.rotation);
                spawnBlueBox = true;
            }
        }

        if (GreenPuzzleTile[0].rotation.y == 0 && GreenPuzzleTile[1].rotation.y == 0 && GreenPuzzleTile[2].rotation.y == 0 && GreenPuzzleTile[3].rotation.y == 0)
        {
            GreenPuzzleSolved = true;
            //Debug.Log("Green Puzzle Solved!!!");

            if (!spawnGreenBox)
            {
                Instantiate(GreenBox, SpawnGreenBox.position, SpawnGreenBox.rotation);
                spawnGreenBox = true;
            }
        }

        if (PurplePuzzleTile[0].rotation.y == 0 &&
            PurplePuzzleTile[1].rotation.y == 0 &&
            PurplePuzzleTile[2].rotation.y == 0 &&
            PurplePuzzleTile[3].rotation.y == 0)
        {
            PurplePuzzleSolved = true;
            //Debug.Log("Purple Puzzle Solved!!!");

            if (!spawnPurpleBox)
            {
                Instantiate(PurpleBox, SpawnPurpleBox.position, SpawnPurpleBox.rotation);
                spawnPurpleBox = true;
            }
        }

        if (RedPuzzleTile[0].rotation.y == 0 &&
            RedPuzzleTile[1].rotation.y == 0 &&
            RedPuzzleTile[2].rotation.y == 0 &&
            RedPuzzleTile[3].rotation.y == 0)
        {
            RedPuzzleSolved = true;
            //Debug.Log("Red Puzzle Solved!!!");

            if (!spawnRedBox)
            {
                Instantiate(RedBox, SpawnRedBox.position, SpawnRedBox.rotation);
                spawnRedBox = true;
            }
        }

        if (YellowPuzzleTile[0].rotation.y == 0 &&
            YellowPuzzleTile[1].rotation.y == 0 &&
            YellowPuzzleTile[2].rotation.y == 0 &&
            YellowPuzzleTile[3].rotation.y == 0)
        {
            YellowPuzzleSolved = true;
            //Debug.Log("Yellow Puzzle Solved!!!");

            if (!spawnYellowBox)
            {
                Instantiate(YellowBox, SpawnYellowBox.position, SpawnYellowBox.rotation);
                spawnYellowBox = true;
            }
        }
    }
}
