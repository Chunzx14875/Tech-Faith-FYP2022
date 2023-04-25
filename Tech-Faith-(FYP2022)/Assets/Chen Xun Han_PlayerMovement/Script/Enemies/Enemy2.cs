using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.UI;

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
    [Header("STUN")]
    [SerializeField] float stunTimeDuration;
    [SerializeField] float stunTimeLeft;
    [SerializeField] bool isCanAttack;
    [SerializeField] GameObject attackRing;
    [SerializeField] GameObject StunParticle;
    private float currentSpeed;

    [Space(25)]
    [Header("HP VALUE")]
    float HpValue = 1f;
    [SerializeField] private Image HpBarFill;

    [Space(25)]
    [Header("AUDIO SOURCE")]
    public AudioSource getHitSound;
    [SerializeField] GameObject explodeSoundPrefab;
    [SerializeField] Transform spawnExplodeSoundPos;

    void Start()
    {
        Sequence mySequence = DOTween.Sequence();

        navMeshAgent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        currentSpeed = navMeshAgent.speed;
        isCanAttack = true;
        StunParticle.SetActive(false);

        StartCoroutine("audioUpdate");

        HpBarFill.fillAmount = HpValue;
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
            //StopCoroutine("stunDuration");
            //StopCoroutine("stunDurationEffect");
            transform.DOKill();
            Instantiate(explodeSoundPrefab, spawnExplodeSoundPos.position, transform.rotation);
            BeingHurted();
        }
        else if (other.CompareTag("Bolt"))
        {
            navMeshAgent.speed = 0;
            isCanAttack = false;
            //transform.DOKill();
            StopCoroutine("stunDuration");
            StopCoroutine("stunDurationEffect");
            StartCoroutine("stunDuration");
            StartCoroutine("stunDurationEffect");
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerCheckDistance);
    }

    void BeingHurted()
    {
        if (HpValue > 0f)
        {
            HpValue -= 0.55f;
            HpBarFill.fillAmount = HpValue;

        }
        if (HpValue <= 0f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator stunDuration()
    {
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
                StopCoroutine("stunDurationEffect");
            }

            yield return null;
        }
    }

    IEnumerator stunDurationEffect()
    {
        while (true)
        {
            getHitSound.PlayOneShot(AudioManager.instance.paralyzed);
            transform.DOPunchPosition(new Vector3(0.3f, 0.3f, 0.3f), 1);
            //yield return new WaitForSecondsRealtime(1f);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator audioUpdate()
    {
        while (true)
        {
            getHitSound.volume = AudioManager.instance.sourceClip.volume;
            yield return null;
        }
    }
}
