using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagneticElectricField : MonoBehaviour
{
    [SerializeField] private Image EnergyBar;
    [SerializeField] private float increasefillSpeed = 4;
    [HideInInspector] public float EnergyAmount = 0f;
    bool CloseToGenerator = false;
    PlayerControl player;

    [Space(25)]
    [Header("MAGNETIC")]
    [SerializeField] private GameObject SmallExplore;
    [SerializeField] private GameObject MediumExplore;
    [SerializeField] private GameObject BigExplore;
    [SerializeField] private ParticleSystem smallExp, mediumExp, bigExp;
    [SerializeField] private float magneticTimeLeft = 0f;
    [SerializeField] private float magneticTimeCooldown;
    [SerializeField] private float timeSpawnMagnetic = 0f;
    [SerializeField] private float timeDelaySpawnMagnetic = 0.3f;
    [SerializeField] private bool isMagnetic;

    [Space(25)]
    [Header("BOLT")]
    [SerializeField] GameObject boltPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float shotTimeLeft = 0f;
    [SerializeField] private float shotTimeCooldown;
    [SerializeField] private float timeSpawnBolt = 0f;
    [SerializeField] private float timeDelaySpawnBolt = 0.3f;
    [SerializeField] private bool isShotBolt;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //CloseToGenerator = false;
        player = GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
        SmallExplore.SetActive(false);
        MediumExplore.SetActive(false);
        BigExplore.SetActive(false);
        EnergyBar.fillAmount = EnergyAmount;
        //StartCoroutine(AddEnergy());
    }

    // Update is called once per frame
    void Update()
    {
        if (magneticTimeLeft >= 0)
        {
            magneticTimeLeft -= 1 * Time.deltaTime;
        }
        else if (magneticTimeLeft <= 0)
        {
            magneticTimeLeft = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (!Input.GetKeyDown(KeyCode.Mouse1)))
        {
            //if (isMagnetic == true)
            //{
            //    if (timeSpawnMagnetic < timeDelaySpawnMagnetic)
            //    {
            //        timeSpawnMagnetic = timeSpawnMagnetic + 1f * Time.deltaTime;
            //    }
            //    else if (timeSpawnMagnetic >= timeDelaySpawnMagnetic)
            //    {
            //        timeSpawnMagnetic = 0;
            //        Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
            //        AudioManager.instance.electricFieldSound(AudioManager.instance.electricField);
            //        isMagnetic = false;
            //    }
            //}
            if (magneticTimeLeft <= 0)
            {
                magneticTimeLeft = magneticTimeCooldown;

                if (EnergyAmount >= 0.4f && EnergyAmount < 0.7f)
                {
                    EnergyAmount = 0;
                    EnergyBar.fillAmount = EnergyAmount;
                    StartCoroutine(ActiveElecField(SmallExplore));
                    smallExp.Play();
                    animator.SetTrigger("IsMagnetic");
                    Debug.Log("Small");
                    //CloseToGenerator = false;

                    AudioManager.instance.electricFieldSound(AudioManager.instance.electricField);
                }
                else if (EnergyAmount >= 0.7f && EnergyAmount < 1f)
                {
                    EnergyAmount = 0;
                    EnergyBar.fillAmount = EnergyAmount;
                    StartCoroutine(ActiveElecField(MediumExplore));
                    mediumExp.Play();
                    animator.SetTrigger("IsMagnetic");
                    Debug.Log("Medium");
                    //CloseToGenerator = false;
                    AudioManager.instance.electricFieldSound(AudioManager.instance.electricField);
                }
                else if (EnergyAmount >= 1f)
                {
                    EnergyAmount = 0;
                    EnergyBar.fillAmount = EnergyAmount;
                    StartCoroutine(ActiveElecField(BigExplore));
                    bigExp.Play();
                    animator.SetTrigger("IsMagnetic");
                    Debug.Log("Big");
                    //CloseToGenerator = false;
                    AudioManager.instance.electricFieldSound(AudioManager.instance.electricField);
                }
            }
            
        }

        #region Shot Bolt Function
        if (shotTimeLeft >= 0)
        {
            shotTimeLeft -= 1 * Time.deltaTime;
        }
        else if (shotTimeLeft <= 0)
        {
            shotTimeLeft = 0;
        }

        if (isShotBolt == true)
        {
            if (timeSpawnBolt < timeDelaySpawnBolt)
            {
                timeSpawnBolt += + 1f * Time.deltaTime;
            }
            else if (timeSpawnBolt >= timeDelaySpawnBolt)
            {
                timeSpawnBolt = 0;
                Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
                AudioManager.instance.electricBoltSound(AudioManager.instance.electricBolt);
                isShotBolt = false;
            }
        }

        if ((Input.GetKeyDown(KeyCode.Mouse1)) && (!Input.GetKeyDown(KeyCode.Mouse0)))
        {
            if (shotTimeLeft <= 0)
            {
                animator.SetTrigger("IsShot");
                isShotBolt = true;
                shotTimeLeft = shotTimeCooldown;

                //if (EnergyAmount >= 0.3f)
                //{
                //    EnergyAmount -= 0.3f;
                //    Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
                //    AudioManager.instance.electricBoltSound(AudioManager.instance.electricBolt);
                //    //Debug.Log("Bolt");
                //}
            }

            //if (Time.time - player.lastGroundTime <= player.jumpButtonGracePeriod)
            //{
            //    if (shotTimeLeft <= 0)
            //    {
            //        Debug.Log("Shot disable");
            //    }
            //}
            //else
            //{
            //    Debug.Log("Shot disable");
            //    if (shotTimeLeft <= 0)
            //    {
            //        animator.SetTrigger("IsShot");
            //        isShotBolt = true;
            //        shotTimeLeft = shotTimeDuration;

            //        //if (EnergyAmount >= 0.3f)
            //        //{
            //        //    EnergyAmount -= 0.3f;
            //        //    Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
            //        //    AudioManager.instance.electricBoltSound(AudioManager.instance.electricBolt);
            //        //    //Debug.Log("Bolt");
            //        //}
            //    }
            //}
        }
        #endregion;

        if (EnergyAmount < 1f)
        {
            if (CloseToGenerator == false)
            {
                EnergyAmount += 0.035f * Time.deltaTime * increasefillSpeed;
                EnergyBar.fillAmount = EnergyAmount;
            }
            else
            {
                EnergyAmount += 0.25f * Time.deltaTime * increasefillSpeed;
                EnergyBar.fillAmount = EnergyAmount;
            }
        }

        if (EnergyAmount >= 1f)
        {
            EnergyAmount = 1;
            EnergyBar.fillAmount = EnergyAmount;
            
            if(player.NumberOfShield < 3 && CloseToGenerator)
            {
                player.NumberOfShield++;
            }
            //CloseToGenerator = false;
        }

        if (EnergyAmount <= 0f)
        {
            EnergyAmount = 0;
            EnergyBar.fillAmount = EnergyAmount;
        }

        Physics.IgnoreLayerCollision(6, 7);
    }

    //void KnockBackForce(float radius)
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

    //    foreach (Collider nearby in colliders)
    //    {

    //        Rigidbody rig = nearby.GetComponent<Rigidbody>();
    //        if(rig != null)
    //        {
    //            rig.AddExplosionForce(ExpForce, transform.position, radius);
    //        }
    //    }

    //}


    IEnumerator ActiveElecField(GameObject field)
    {
        field.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        field.SetActive(false);
        //CloseToGenerator = false;
    }

    //public void ShotBolt()
    //{
    //    if (shotBlocked)
    //        return;
    //    animator.SetTrigger("IsShot");
    //    Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
    //    AudioManager.instance.electricBoltSound(AudioManager.instance.electricBolt);
    //    shotBlocked = true;
    //    StartCoroutine("DelayShot");
    //}

    //IEnumerator DelayShot()
    //{
    //    yield return new WaitForSeconds(delayShot);
    //    shotBlocked = false;
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Generator"))
        {
            CloseToGenerator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Generator"))
        {
            CloseToGenerator = false;
        }
    }

    //IEnumerator AddEnergy()
    //{
    //    if(EnergyAmount < 1f)
    //    {
    //        if (CloseToGenerator)
    //        {
    //            EnergyAmount += 0.25f * Time.deltaTime * increasefillSpeed;
    //            EnergyBar.fillAmount = EnergyAmount;
    //        }
    //        else
    //        {
    //            EnergyAmount += 0.035f * Time.deltaTime * increasefillSpeed;
    //            EnergyBar.fillAmount = EnergyAmount;
    //        }
    //    }

    //    yield return new WaitForSeconds(0.25f);

    //    StartCoroutine(AddEnergy());
    //}

    //void CheckBool()
    //{
    //    if(CloseToGenerator == true)
    //    {
    //        StartCoroutine(ResetBool());
    //    }
    //}

    //IEnumerator ResetBool()
    //{

    //    yield return new WaitForSeconds(0.01f);

    //    CloseToGenerator = false;
    //}
}
