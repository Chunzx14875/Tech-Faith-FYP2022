using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPuzzleManager : MonoBehaviour
{
    public static TutorialPuzzleManager instance;

    public List<int> sequence;
    public List<int> addedSeq;

    [Space(25)]
    [Header("DOOR")]
    [SerializeField] Transform doorLeft;
    [SerializeField] Transform doorRight;
    Vector3 doorLeftStartPos;
    Vector3 doorRightStartPos;

    [Header("Blue Puzzle")]
    [Space(25)]
    public bool blue_puzzle_solve = false;
    [SerializeField] RectTransform[] BluePuzzleTile;

    [Header("Green Puzzle")]
    [Space(25)]
    public bool green_puzzle_solve = false;
    [SerializeField] RectTransform[] GreenPuzzleTile;

    [Header("Purple Puzzle")]
    [Space(25)]
    public bool purple_puzzle_solve = false;
    [SerializeField] RectTransform[] PurplePuzzleTile;

    [Header("Red Puzzle")]
    [Space(25)]
    public bool red_puzzle_solve = false;
    [SerializeField] RectTransform[] RedPuzzleTile;

    [Header("Yellow Puzzle")]
    [Space(25)]
    public bool yellow_puzzle_solve = false;
    [SerializeField] Image[] YellowPuzzleTile;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
