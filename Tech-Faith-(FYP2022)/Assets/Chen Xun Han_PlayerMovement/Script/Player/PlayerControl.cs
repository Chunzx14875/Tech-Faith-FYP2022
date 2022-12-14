using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("MOVEMENT")]
    //[Space(15)]
    [SerializeField] private float maximumSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpHorizontalSpeed;
    [HideInInspector] public float jumpButtonGracePeriod;

    [SerializeField] private Transform cameraTransform;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float orignalStepOffset;
    [HideInInspector] public float? lastGroundTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    [HideInInspector] public bool isGrounded;

    [Space(25)]
    [Header("LOSE")]
    public GameObject gameMenuCanvas;
    GameMenu gameMenu;

    Vector3 respawn;

    [Space(25)]
    [Header("SHIELD")]
    public int NumberOfShield = 3;
    [SerializeField] private GameObject FirstShield;
    [SerializeField] private GameObject SecondShield;
    [SerializeField] private GameObject ThirdShield;
    bool isInvincible = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        orignalStepOffset = characterController.stepOffset;

        gameMenu = gameMenuCanvas.GetComponent<GameMenu>();
        respawn = transform.position;

        NumberOfShield = 3;
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        //if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        //{
        //    //inputMagnitude /= 2;
        //    inputMagnitude *= 2;
        //}

        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
        //float speed = inputMagnitude * maximumSpeed; 
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
            //Debug.Log("Jump");
        }

        if (Time.time - lastGroundTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = orignalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);


            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                animator.SetBool("IsJumping", true);
                isJumping = true;
                jumpButtonPressedTime = null;
                lastGroundTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("IsGrounded", false);
            isGrounded = false;

            if ((isJumping && ySpeed < 0) || ySpeed < -2)
            {
                animator.SetBool("IsFalling", true);
            }
        }

        //Vector3 velocity = movementDirection * speed;
        //velocity.y = ySpeed;

        //characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (isGrounded == false)
        {
            Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
            velocity.y = ySpeed;

            characterController.Move(velocity * Time.deltaTime);
        }

        ActiveShield();
    }

    private void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 velocity = animator.deltaPosition;
            velocity = AdjustVelocityToSlope(velocity);
            velocity.y += ySpeed * Time.deltaTime;

            characterController.Move(velocity);
        }
    }

    private Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        var ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f))
        {
            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedVelocity = slopeRotation * velocity;

            if(adjustedVelocity.y < 0)
            {
                return adjustedVelocity;
            }
        }

        return velocity;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void ActiveShield()
    {
        if(NumberOfShield == 3)
        {
            FirstShield.SetActive(true);
            SecondShield.SetActive(true);
            ThirdShield.SetActive(true);
            
        }
        else if (NumberOfShield == 2)
        {
            FirstShield.SetActive(false);
            SecondShield.SetActive(true);
            ThirdShield.SetActive(true);
        }
        else if (NumberOfShield == 1)
        {
            FirstShield.SetActive(false);
            SecondShield.SetActive(false);
            ThirdShield.SetActive(true);
        }
        else
        {
            FirstShield.SetActive(false);
            SecondShield.SetActive(false);
            ThirdShield.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)   
    {
        if (other.CompareTag("Damage"))
        {
            if (!isInvincible)
            {
                if (NumberOfShield == 0)
                {
                    gameMenu.losePanelOpen();
                    AudioManager.instance.playerExplodeSound(AudioManager.instance.playerExplode);
                    Destroy(gameObject);
                    Debug.Log("Player dead");
                    StartCoroutine(Invincible());
                }
                else
                {
                    NumberOfShield--;
                    AudioManager.instance.shieldBreakSound(AudioManager.instance.shieldBreak);
                    Debug.Log(NumberOfShield);
                    StartCoroutine(Invincible());
                }
            }
        }
        if (other.CompareTag("Respawn"))
        {
            characterController.enabled = false;
            transform.position = respawn;
            characterController.enabled = true;
            Debug.Log("Touch Respawn Area");
        }
        if (other.CompareTag("CheckPoint"))
        {
            respawn = other.transform.position;
            Debug.Log("Touch Checkpoint");
        }
    }

    IEnumerator Invincible()
    {
        isInvincible = true;

        yield return new WaitForSeconds(1f);

        isInvincible = false;
    }
}
