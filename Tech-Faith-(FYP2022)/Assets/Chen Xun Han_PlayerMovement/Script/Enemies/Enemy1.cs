using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.UI;

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

    [Space(25)]
    [Header("STUN")]
    [SerializeField] float stunTimeDuration;
    [SerializeField] float stunTimeLeft;
    [SerializeField] bool isCanAttack;
    [SerializeField] GameObject StunParticle;
    private float currentSpeed;

    [Space(25)]
    [Header("HP VALUE")]
    float HpValue = 1f;
    [SerializeField] private Image HpBarFill;

    [Space(25)]
    [Header("AUDIO SOURCE")]
    public AudioSource shotLaserSound;
    public AudioSource getHitSound;
    [SerializeField] GameObject explodeSoundPrefab;
    [SerializeField] Transform spawnExplodeSoundPos;

    

    void Start()
    {
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

                if (distance <= navMeshAgent.stoppingDistance && isCanAttack == true)
                {
                    targetDir = (player.position - transform.position).normalized;
                    targetDir.y = 0;

                    currentDir = Vector3.RotateTowards(transform.forward, targetDir, 3 * Time.deltaTime, 0f);
                    transform.rotation = Quaternion.LookRotation(currentDir);

                    if (countdownBetweenFire <= 0f)
                    {
                        foreach (Transform spawnPoint in projectileSpawnPoint)
                        {
                            shotLaserSound.PlayOneShot(AudioManager.instance.laserClip);
                            //AudioManager.instance.laserClipSound(AudioManager.instance.laserClip);
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
            StopCoroutine("stunDuration");
            StopCoroutine("stunDurationEffect");
            StartCoroutine("stunDuration");
            StartCoroutine("stunDurationEffect");
            Debug.Log("Stun");
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
        if(HpValue > 0f)
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
            shotLaserSound.volume = AudioManager.instance.sourceClip.volume;
            yield return null;
        }
    }
}
