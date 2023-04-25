using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpAndDrop : MonoBehaviour
{
    [Header("Pick up")]
    [Space(1)]
    [SerializeField] private Transform HoldArea;
    [SerializeField] private Transform RaycastFrom;
    GameObject heldObj;
    Rigidbody heldObjRB;
    BoxCollider heldObjCollider;
    [Space(5)]

    [Header("Physics Parameters")]
    [Space(1)]
    [SerializeField] private float pickUpRange = 1f;
    [SerializeField] private float pickUpForce = 100f;
    [Space(5)]

    [Header("FUNCTIONS DELAY")]
    [Space(1)]
    [SerializeField] private bool isPick;
    [SerializeField] private float pickUpDelay = 1f;

    PlayerControl player;
    GameMenu gameMenu;
    private Animator animator;
    private string currentState;

    //Animation States
    const string PICK_OBJECT = "Pick Object";
    const string JUMP_DOWN_STANDING = "Jump Down Standing";
    const string MOVING = "Movement Blend Tree";

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerControl>();
        gameMenu = player.gameMenuCanvas.GetComponent<GameMenu>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayhit;

        if (Physics.Raycast(RaycastFrom.transform.position, transform.forward, out rayhit, pickUpRange))
        {
            if (rayhit.transform.gameObject.CompareTag("CanPick"))
            {
                HintBox.instance.TextBox.SetActive(true);
                HintBox.instance.hintText.text = "Press 'E' to pick up";
            }
            else if (rayhit.transform.gameObject.CompareTag("Based"))
            {
                HintBox.instance.TextBox.SetActive(true);
                HintBox.instance.hintText.text = "Press 'E' to switch on";
            }
            else if (rayhit.transform.gameObject.CompareTag("Key"))
            {
                HintBox.instance.TextBox.SetActive(true);
                HintBox.instance.hintText.text = "Press 'E' to pick key";
            }
            else
            {
                HintBox.instance.TextBox.SetActive(false);
                HintBox.instance.hintText.text = "";
            }
        }
        else
        {
            if (heldObj == null)
            {
                HintBox.instance.TextBox.SetActive(false);
                HintBox.instance.hintText.text = "";
            }
        }


        if (Input.GetKeyDown(KeyCode.E) && (gameMenu.openOption == false))
        {
            if (heldObj == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(RaycastFrom.transform.position, transform.forward, out hit, pickUpRange))
                {

                    if (hit.transform.gameObject.CompareTag("CanPick"))
                    {

                        if (!isPick)
                        {
                            //Pick Up object
                            animator.SetBool("IsMoving", false);

                            player.isPressed = true;
                            player.isPressedPickObj = true;
                            player.disableInput = true;
                            isPick = true;
                            ChangeAnimationState(PICK_OBJECT);
                            animator.SetLayerWeight(1, 0f);
                            PickUpObject(hit.transform.gameObject);
                            Invoke("PickComplete", pickUpDelay);
                            Invoke("pressComplete", 1);
                            pickUpRange = 0;

                            HintBox.instance.TextBox.SetActive(true);
                            HintBox.instance.hintText.text = "Press 'E' to drop";
                        }
                    }

                }
            }
            else if (heldObj != null && isPick == false)
            {
                //Drop object

                HintBox.instance.TextBox.SetActive(false);
                HintBox.instance.hintText.text = "";
                pickUpRange = 1f;

                animator.SetBool("IsMoving", false);

                player.isPressed = false;
                player.isPressedPickObj = false;
                animator.SetLayerWeight(2, 0f);
                DropObject();
                Debug.Log("drop");

            }
        }



        //    if (Input.GetKeyDown(KeyCode.E) && (gameMenu.openOption == false))
        //    {
        //        if (heldObj == null)
        //        {
        //            if (hit.transform.gameObject.CompareTag("CanPick"))
        //            {

        //                if (!isPick)
        //                {
        //                    animator.SetBool("IsMoving", false);

        //                    player.isPressed = true;
        //                    player.isPressedPickObj = true;
        //                    player.disableInput = true;
        //                    isPick = true;
        //                    ChangeAnimationState(PICK_OBJECT);
        //                    animator.SetLayerWeight(1, 0f);
        //                    PickUpObject(hit.transform.gameObject);
        //                    Invoke("PickComplete", pickUpDelay);
        //                    Invoke("pressComplete", 1);

        //                    HintBox.instance.TextBox.SetActive(true);
        //                    HintBox.instance.hintText.text = "Press 'E' to drop";

        //                }
        //            }

        //        }
        //        else if (heldObj != null && isPick == false)
        //        {
        //            HintBox.instance.TextBox.SetActive(false);
        //            HintBox.instance.hintText.text = "";

        //            animator.SetBool("IsMoving", false);

        //            player.isPressed = false;
        //            player.isPressedPickObj = false;
        //            animator.SetLayerWeight(2, 0f);
        //            DropObject();
        //            Debug.Log("drop");
        //        }
        //    }
        //}
        //else
        //{
        //    HintBox.instance.TextBox.SetActive(false);
        //    HintBox.instance.hintText.text = "";
        //}


        if (heldObj != null)
        {
            MoveObject();
        }

        if(heldObj != null && player.isGrounded == false)
        {
            ChangeAnimationState2(JUMP_DOWN_STANDING);
        }

        Debug.DrawRay(transform.position, transform.forward * pickUpRange, Color.green);
    }

    void PickComplete()
    {
        isPick = false;
        animator.SetLayerWeight(1, 1f);
        animator.SetLayerWeight(2, 1f);
    }

    void pressComplete()
    {
        player.disableInput = false;
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, HoldArea.position) > 0.05f)
        {
            Vector3 moveDirection = (HoldArea.position - heldObj.transform.position);

            heldObjRB.AddForce(moveDirection * pickUpForce);
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>())
        {
            heldObjCollider = pickObj.GetComponent<BoxCollider>();
            //heldObjCollider.enabled = false;
            Invoke("InableCollider", 0.1f);


            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            //heldObjRB.mass = 0;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = HoldArea;
            heldObj = pickObj;
        }
    }

    void InableCollider()
    {
        heldObjCollider.enabled = false;
    }

    void DropObject()
    {
        heldObjCollider.enabled = true;

        heldObjRB.useGravity = true;
        heldObjRB.drag = 0;
        //heldObjRB.mass = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;
    }

    void ChangeAnimationState(string newState)
    {
        //Stop the same animation from interrupting itself
        //if (currentState == newState) return;

        //Play the animation
        animator.Play(newState);

        //Reassign the current state
        currentState = newState;
    }

    void ChangeAnimationState2(string newState2)
    {
        //Stop the same animation from interrupting itself
        //if (currentState == newState2) return;

        //Play the animation
        animator.Play(newState2, 1, 0f);

        //Reassign the current state
        currentState = newState2;
    }
}
