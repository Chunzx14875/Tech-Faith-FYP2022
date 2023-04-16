using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    public static CollectKey instance;

    [Header("Physics Parameters")]
    [Space(1)]
    [SerializeField] private Transform RaycastFrom;
    [SerializeField] private float RaycastRange = 1f;
    [SerializeField] private bool detectKey = false;
    //[SerializeField] private Animator anim;
    public bool hasKey;

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
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayhit;

        if (Physics.Raycast(RaycastFrom.transform.position, transform.forward, out rayhit, RaycastRange))
        {
            if (rayhit.transform.gameObject.CompareTag("Key"))
            {
                detectKey = true;
            }
            else
            {
                detectKey = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && detectKey)
        {
            hasKey = true;
            detectKey = false;
            Destroy(rayhit.transform.gameObject);
            Debug.Log("Collect Key");
        }
    }
}
