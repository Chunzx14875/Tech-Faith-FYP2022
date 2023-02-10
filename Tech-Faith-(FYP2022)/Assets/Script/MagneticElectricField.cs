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

    [Space(25)]
    [Header("MAGNETIC")]
    [SerializeField] private GameObject SmallExplore;
    [SerializeField] private GameObject MediumExplore;
    [SerializeField] private GameObject BigExplore;
    [SerializeField] private ParticleSystem smallExp, mediumExp, bigExp;
    [SerializeField] private ParticleSystem smallSpark, mediumSpark, bigSpark;

    [Space(25)]
    [Header("BOLT")]
    [SerializeField] GameObject boltPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float timeSpawnBolt = 0f;
    [SerializeField] private float timeDelaySpawnBolt = 0.3f;
    [SerializeField] private bool isShotBolt;
    [SerializeField] private float pressTimeLeft;

    PlayerControl player;
    GameMenu gameMenu;
    private Animator animator;
    private string currentState;

    //Animation States
    const string SHOT_ELECTRIC_BOLT = "Shot Electric Bolt";
    const string MAGNETIC_ELECTRIC_FIELD = "Magnetic Electric Field";
    const string JUMP_DOWN_STANDING = "Jump Down Standing";

    // Start is called before the first frame update
    void Start()
    {
        //CloseToGenerator = false;
        player = GetComponent<PlayerControl>();
        gameMenu = player.gameMenuCanvas.GetComponent<GameMenu>();
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
        if(EnergyAmount >= 0.4f)
        {
            EnergyBar.color = Color.yellow;
        }
        else
        {
            EnergyBar.color = Color.red;
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (player.isPressed == false) && (gameMenu.openOption == false))
        {
            player.isPressed = true;
            player.disableInput = true;

            if (player.isPressed == true)
            {
                player.pressTimeLeft = player.pressTimeCooldown;
                //animator.SetBool("IsMoving", false);

                if (EnergyAmount >= 0.4f && EnergyAmount < 0.7f)
                {
                    EnergyAmount = 0;
                    EnergyBar.fillAmount = EnergyAmount;
                    StartCoroutine(ActiveElecField(SmallExplore));
                    smallExp.Play();
                    smallSpark.Play();

                    if (player.isGrounded == true)
                    {
                        ChangeAnimationState(MAGNETIC_ELECTRIC_FIELD);
                        //animator.SetLayerWeight(1, 0f);
                    }
                    else
                    {
                        ChangeAnimationState(MAGNETIC_ELECTRIC_FIELD);
                        ChangeAnimationState2(JUMP_DOWN_STANDING);
                    }

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
                    mediumSpark.Play();

                    if (player.isGrounded == true)
                    {
                        ChangeAnimationState(MAGNETIC_ELECTRIC_FIELD);
                        //animator.SetLayerWeight(1, 0f);
                    }
                    else
                    {
                        ChangeAnimationState(MAGNETIC_ELECTRIC_FIELD);
                        ChangeAnimationState2(JUMP_DOWN_STANDING);
                    }

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
                    bigSpark.Play();

                    if (player.isGrounded == true)
                    {
                        ChangeAnimationState(MAGNETIC_ELECTRIC_FIELD);
                        //animator.SetLayerWeight(1, 0f);
                    }
                    else
                    {
                        ChangeAnimationState(MAGNETIC_ELECTRIC_FIELD);
                        ChangeAnimationState2(JUMP_DOWN_STANDING);
                    }

                    Debug.Log("Big");
                    //CloseToGenerator = false;
                    AudioManager.instance.electricFieldSound(AudioManager.instance.electricField);
                }

                Invoke("pressComplete", player.delayPlayerInput);
            }
            
        }

        #region Shot Bolt Function
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

        if ((Input.GetKeyDown(KeyCode.Mouse1)) && (player.isPressed == false) && (gameMenu.openOption == false))
        {
            player.isPressed = true;
            player.disableInput = true;

            if (player.isPressed == true)
            {
                player.pressTimeLeft = player.pressTimeCooldown;

                //animator.SetBool("IsMoving", false);

                if (player.isGrounded == true)
                {
                    ChangeAnimationState(SHOT_ELECTRIC_BOLT);
                    //animator.SetLayerWeight(1, 0f);
                }
                else
                {
                    ChangeAnimationState(SHOT_ELECTRIC_BOLT);
                    ChangeAnimationState2(JUMP_DOWN_STANDING);
                }

                isShotBolt = true;
                Invoke("pressComplete", player.delayPlayerInput);

                //if (EnergyAmount >= 0.3f)
                //{
                //    EnergyAmount -= 0.3f;
                //    Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
                //    AudioManager.instance.electricBoltSound(AudioManager.instance.electricBolt);
                //    //Debug.Log("Bolt");
                //}
            }
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

    void pressComplete()
    {
        player.disableInput = false;
        animator.SetLayerWeight(1, 1f);
    }

    IEnumerator ActiveElecField(GameObject field)
    {
        field.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        field.SetActive(false);
        //CloseToGenerator = false;
    }

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

    void ChangeAnimationState(string newState)
    {
        //Stop the same animation from interrupting itself
        //if (currentState == newState) return;

        //Play the animation
        animator.Play(newState);
        //animator.GetComponent<Animator>().Play(newState, -1, 0);

        //Reassign the current state
        currentState = newState;
    }

    void ChangeAnimationState2(string newState2)
    {
        //Stop the same animation from interrupting itself
        if (currentState == newState2) return;

        //Play the animation
        animator.Play(newState2, 1);

        //Reassign the current state
        currentState = newState2;
    }
}
