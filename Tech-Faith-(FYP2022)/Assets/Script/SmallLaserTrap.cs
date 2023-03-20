using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallLaserTrap : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField] Transform startPoint;
    [SerializeField] int MaxBounce;
    [SerializeField] bool reflectOnMirror;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, startPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        CastLaser(transform.position, -transform.forward);
        //lr.SetPosition(0, startPoint.position);

        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, transform.forward, out hit))
        //{
        //    if (hit.collider)
        //    {
        //        lr.SetPosition(1, hit.point);
        //    }
        //    if (hit.collider.gameObject.CompareTag("Player"))
        //    {
        //        lr.SetPosition(1, hit.point);
        //        Debug.Log("Hit Player");
        //    }
        //}
        //else
        //{
        //    lr.SetPosition(1, transform.forward * 5000);
        //}
    }

    void CastLaser(Vector3 position, Vector3 direction)
    {
        lr.SetPosition(0, startPoint.position);

        for (int i = 0; i < MaxBounce; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5000))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lr.SetPosition(i + 1, hit.point);  

                if (hit.collider.GetComponent<Mirror>() != null && reflectOnMirror)
                {
                    for (int j = (i + 1); j <= 5; j++)
                    {
                        lr.SetPosition(j, hit.point);
                    }
                    break;
                }

                Debug.Log()
            }
        }
    }
}
