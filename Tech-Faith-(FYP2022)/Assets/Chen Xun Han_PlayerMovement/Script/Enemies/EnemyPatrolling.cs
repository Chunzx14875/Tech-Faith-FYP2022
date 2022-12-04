using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolling : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Vector3 targetPoint;

    [Header("PATROLLING")]
    [SerializeField] Transform[] pathPoints;
    [SerializeField] int i;
    [SerializeField] Transform patrollingArea;

    [Space(25)]
    [Header("CHASING")]
    [SerializeField] Transform player;
    [SerializeField] float playerCheckDistance;

    [SerializeField] bool isfound;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
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
        targetPoint = player.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (patrollingArea)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < playerCheckDistance)
            {
                isfound = true;
            }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerCheckDistance);
    }
}
