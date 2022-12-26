using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagneticElectricField : MonoBehaviour
{
    [SerializeField] private Image EnergyBar;
    [SerializeField] private GameObject SmallExplore;
    [SerializeField] private GameObject MediumExplore;
    [SerializeField] private GameObject BigExplore;
    [SerializeField] private ParticleSystem smallExp, mediumExp, bigExp;
    [SerializeField] private float increasefillSpeed = 4;
    [HideInInspector] public float EnergyAmount = 0f;
    bool CloseToGenerator = false;
    PlayerControl player;

    [SerializeField] GameObject boltPrefab;
    [SerializeField] Transform spawnPoint;
    MagneticElectricField magnetic;

    // Start is called before the first frame update
    void Start()
    {
        //CloseToGenerator = false;
        player = GetComponent<PlayerControl>();
        SmallExplore.SetActive(false);
        MediumExplore.SetActive(false);
        BigExplore.SetActive(false);
        EnergyBar.fillAmount = EnergyAmount;
        //StartCoroutine(AddEnergy());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            if (EnergyAmount >= 0.4f && EnergyAmount < 0.7f)
            {
                EnergyAmount = 0;
                EnergyBar.fillAmount = EnergyAmount;
                StartCoroutine(ActiveElecField(SmallExplore));
                smallExp.Play();

                Debug.Log("Small");
                //CloseToGenerator = false;

            }
            else if (EnergyAmount >= 0.7f && EnergyAmount < 1f)
            {
                EnergyAmount = 0;
                EnergyBar.fillAmount = EnergyAmount;
                StartCoroutine(ActiveElecField(MediumExplore));
                mediumExp.Play();

                Debug.Log("Medium");
                //CloseToGenerator = false;
            }
            else if (EnergyAmount >= 1f)
            {
                EnergyAmount = 0;
                EnergyBar.fillAmount = EnergyAmount;
                StartCoroutine(ActiveElecField(BigExplore));
                bigExp.Play();

                Debug.Log("Big");
                //CloseToGenerator = false;
            }

            
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (EnergyAmount >= 0.3f)
            {
                EnergyAmount -= 0.3f;
                Instantiate(boltPrefab, spawnPoint.position, transform.rotation);
                //Debug.Log("Bolt");
            }
        }

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
        CloseToGenerator = false;
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
}
