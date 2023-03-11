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
            Debug.Log("Blue Puzzle Solved!!!");

            if(!spawnBlueBox)
            {
                Instantiate(BlueBox, SpawnBlueBox.position, SpawnBlueBox.rotation);
                spawnBlueBox = true;
            }
        }
    }
}
