using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
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
    [SerializeField] Transform[] projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    float countdownBetweenFire = 0f;
    [SerializeField] float fireRate = 2f;
    Vector3 targetDir;
    Vector3 currentDir;

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
        navMeshAgent.stoppingDistance = 0;

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
            navMeshAgent.stoppingDistance = 5;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (player != null)
        {
            if (patrollingArea)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);

                if (distance <= playerCheckDistance)
                {
                    isfound = true;
                }

                if (distance <= navMeshAgent.stoppingDistance)
                {
                    targetDir = (player.position - transform.position).normalized;
                    targetDir.y = 0;

                    currentDir = Vector3.RotateTowards(transform.forward, targetDir, 3 * Time.deltaTime, 0f);
                    transform.rotation = Quaternion.LookRotation(currentDir);

                    if (countdownBetweenFire <= 0f)
                    {
                        foreach (Transform spawnPoint in projectileSpawnPoint)
                        {
                            AudioManager.instance.laserClipSound(AudioManager.instance.laserClip);
                            Instantiate(projectilePrefab, spawnPoint.position, transform.rotation);
                        }

                        countdownBetweenFire = 1f / fireRate;
                    }

                    countdownBetweenFire -= Time.deltaTime;
                }
            }
        }
        else
        {
            isfound = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ElectricField"))
        {
            Destroy(gameObject, 1.5f);
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
