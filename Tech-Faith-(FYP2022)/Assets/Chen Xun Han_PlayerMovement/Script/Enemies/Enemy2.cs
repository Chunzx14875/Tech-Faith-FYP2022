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

    [Space(25)]
    [Header("STUN")]
    [SerializeField] float stunTimeDuration;
    [SerializeField] float stunTimeLeft;
    [SerializeField] bool isCanAttack;
    [SerializeField] GameObject attackRing;
    [SerializeField] GameObject StunParticle;
    private float currentSpeed;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentSpeed = navMeshAgent.speed;
        isCanAttack = true;
        StunParticle.SetActive(false);
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

            if(isCanAttack == false)
            {
                attackRing.SetActive(false);
            }
            else
            {
                attackRing.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ElectricField"))
        {
            Destroy(gameObject, 1.5f);
        }
        else if (other.CompareTag("Bolt"))
        {
            navMeshAgent.speed = 0;
            isCanAttack = false;
            StopCoroutine("stunDuration");
            StartCoroutine("stunDuration");
            StartCoroutine("stunDurationSound");
            Debug.Log("Stun");
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

    IEnumerator stunDuration()
    {
        StopCoroutine("stunDurationSound");
        stunTimeLeft = stunTimeDuration;

        while (true)
        {
            stunTimeLeft -= 1 * Time.deltaTime;
            StunParticle.SetActive(true);

            if (stunTimeLeft <= 0)
            {
                navMeshAgent.speed = currentSpeed;
                isCanAttack = true;
                StunParticle.SetActive(false);
                Debug.Log("Stun time out");
                StopCoroutine("stunDuration");
                StopCoroutine("stunDurationSound");
            }

            yield return null;
        }
    }

    IEnumerator stunDurationSound()
    {
        while (true)
        {
            AudioManager.instance.paralyzedSound(AudioManager.instance.paralyzed);
            yield return new WaitForSeconds(2f);
        }
    }
}
