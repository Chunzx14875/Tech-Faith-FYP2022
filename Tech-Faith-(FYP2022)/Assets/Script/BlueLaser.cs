using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaser : MonoBehaviour
{
    [SerializeField] private int reflections;
    [SerializeField] private float MaxLength;

    private LineRenderer lr;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    [SerializeField] GameObject Box;
    [SerializeField] Transform SpawnBox;
    bool spawnBox = false;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
        float remaingLength = MaxLength;

        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remaingLength))
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, hit.point);
                remaingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.GetComponent<BlueMirror>() == null)
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        Debug.Log("Hit Player");
                        break;
                    }
                    if (hit.collider.gameObject.name == "BluePicture")
                    {
                        if (!spawnBox)
                        {
                            Instantiate(Box, SpawnBox.position, SpawnBox.rotation);
                            spawnBox = true;
                            Debug.Log("Drop Blue Box!");
                        }

                        break;
                    }

                    break;
                }
            }
            else
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, ray.origin + ray.direction * remaingLength);
            }
        }
    }
}
