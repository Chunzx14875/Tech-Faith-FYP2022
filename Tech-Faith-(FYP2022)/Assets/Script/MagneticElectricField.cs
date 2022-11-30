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
    [SerializeField] private float ExpForce, smallRad, mediumRad, bigRad;
    private float EnergyAmount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SmallExplore.SetActive(false);
        MediumExplore.SetActive(false);
        BigExplore.SetActive(false);
        EnergyBar.fillAmount = EnergyAmount;
        StartCoroutine(AddEnergy());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(EnergyAmount >= 0.4f && EnergyAmount < 0.7f)
            {
                EnergyAmount = 0;
                EnergyBar.fillAmount = EnergyAmount;
                StartCoroutine(ActiveElecField(SmallExplore));
                //KnockBackForce(smallRad);
                Debug.Log("Small");

            }
            else if(EnergyAmount >= 0.7f && EnergyAmount < 1f)
            {
                EnergyAmount = 0;
                EnergyBar.fillAmount = EnergyAmount;
                StartCoroutine(ActiveElecField(MediumExplore));
                //KnockBackForce(mediumRad);
                Debug.Log("Medium");
            }
            else if(EnergyAmount >= 1f)
            {
                EnergyAmount = 0;
                EnergyBar.fillAmount = EnergyAmount;
                StartCoroutine(ActiveElecField(BigExplore));
                //KnockBackForce(bigRad);
                Debug.Log("Big");
            }
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
        yield return new WaitForSeconds(0.01f);
        field.SetActive(false);
    }


    IEnumerator AddEnergy()
    {
        if(EnergyAmount < 1f)
        {
            EnergyAmount += 0.025f;
            EnergyBar.fillAmount = EnergyAmount;
        }

        yield return new WaitForSeconds(0.25f);

        StartCoroutine(AddEnergy());
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, smallRad);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, mediumRad);

        //Gizmos.color = Color.green;
        //Gizmos.DrawSphere(transform.position, bigRad);
    }
}
