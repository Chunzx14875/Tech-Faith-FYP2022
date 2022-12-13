using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Vector3 targetPoint;

    [Header("PATROLLING")]
    [SerializeField] Transform[] pathPoints;
    [SerializeField] int i;
    [SerializeField] Transform patrollingArea;

    [Space(25)]
    [Header("CHASING")]
    Transform player;
    [SerializeField] float playerCheckDistance;
    [SerializeField] bool isfound;

    [Space(25)]
    [Header("ATTACK")]
    [SerializeField] float damage;
    [SerializeField] float damagePerSec;
    [SerializeField] float timeLeft;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (navMeshAgent == null)
        {
            Debug.Log("Not attached");
        }
        else
        {
            if (!isfound)
            {
                Patrolling();
            }
            else
            {
                Chasing();
            }

            navMeshAgent.SetDestination(targetPoint);

        }
    }

    void Patrolling()
    {
        targetPoint = pathPoints[i].position;

        if (pathPoints != null)
        {
            if ((targetPoint - transform.position).magnitude < 1f)
            {
                i++;

                if (i == pathPoints.Length)
                {
                    i = 0;
                }
            }
        }
    }

    void Chasing()
    {
        if (player != null)
        {
            targetPoint = player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ElectricField"))
        {
            Destroy(gameObject, 1.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (player != null)
        {
            if (patrollingArea)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);

                if (distance < playerCheckDistance)
                {
                    isfound = true;
                }
            }
            else if (other.CompareTag("Player"))
            {
                Debug.Log("damage");
            }
        }
        else
        {
            isfound = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (patrollingArea)
        {
            isfound = false;
            //Debug.Log("Return");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        StartCoroutine("DamagePlayer");
    //        Debug.Log("count damage sec");
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerCheckDistance);
    }

    //IEnumerator DamagePlayer()
    //{
    //    timeLeft = damagePerSec;

    //    while (true)
    //    {
    //        timeLeft -= 1 * Time.deltaTime;

    //        if(timeLeft <= 0)
    //        {
    //            Debug.Log("damage");
    //            timeLeft = damagePerSec;
    //        }

    //        yield return null;
    //    }
    //}
}
