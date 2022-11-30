using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    //public static CameraLogic instance;

    public GameObject cameraTarget;
    public GameObject avatarParent;

    public GameObject minPos;
    public GameObject maxPos;

    Vector3 targetPos;
    public float cameraValue;
    float rotationY;


    //public GameObject targetTutorial;
    //public GameObject tutorialArrow;

    Vector3 speed;
    bool hold;
    // Start is called before the first frame update
    void Start()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}

        cameraTarget = GameObject.Find("CameraPivot");
        avatarParent = GameObject.Find("Player");
        minPos = GameObject.Find("CameraStart");
        maxPos = GameObject.Find("CameraEnd");
        //Player2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        cameraValue += Input.GetAxis("Mouse Y") * 0.05f;
        cameraValue = Mathf.Clamp(cameraValue, 0, 1);
        cameraTarget.transform.position = Vector3.Lerp(minPos.transform.position, maxPos.transform.position, cameraValue);
        cameraTarget.transform.rotation = Quaternion.Lerp(minPos.transform.rotation, maxPos.transform.rotation, cameraValue);
        rotationY += Input.GetAxis("Mouse X") * 2.5f;

        transform.position = Vector3.Lerp(transform.position, cameraTarget.transform.position, Time.deltaTime * 6);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.transform.rotation, Time.deltaTime * 6);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        avatarParent.transform.localEulerAngles = new Vector3(0, rotationY, 0);

        //hold = false;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    hold = true;
        //    //speed += avatarParent.transform.forward * Time.deltaTime * 2f;
        //    avatarParent.transform.position += avatarParent.transform.forward * Time.deltaTime * 15f;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    hold = true;
        //    //speed -= avatarParent.transform.forward * Time.deltaTime * 2f;
        //    avatarParent.transform.position -= avatarParent.transform.forward * Time.deltaTime * 15f;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    hold = true;
        //    //speed -= avatarParent.transform.right * Time.deltaTime * 2f;
        //    avatarParent.transform.position -= avatarParent.transform.right * Time.deltaTime * 15f;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    hold = true;
        //    //speed += avatarParent.transform.right * Time.deltaTime * 2f;
        //    avatarParent.transform.position += avatarParent.transform.right * Time.deltaTime * 15f;
        //}
        //if (!hold)
        //{
        //    if (speed.magnitude > 0)
        //    {
        //        speed -= speed * Time.deltaTime * 10;
        //    }
        //}
        //speed = Vector3.ClampMagnitude(speed, 5f);
        //avatarParent.transform.position += speed * Time.deltaTime;

        //Quaternion _lookRotation = Quaternion.LookRotation((new Vector3(targetTutorial.transform.position.x, avatarParent.transform.position.y, targetTutorial.transform.position.z) - avatarParent.transform.position).normalized);
        //tutorialArrow.transform.rotation = _lookRotation;

    }
}
