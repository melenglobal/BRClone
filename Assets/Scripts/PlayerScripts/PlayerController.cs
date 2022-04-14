using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private CharacterController characterController;

    public Transform transformCamera;

    [SerializeField]
    private float stickToGroundForce = 9.8f;

    [SerializeField]
    private float verticalVelocity;

    [SerializeField]
    private FloatingJoystick floatingJoystick;


    public float speed;

    public float rotationSpeed;


    private bool isGround;

    Vector3 movementDirection;

    private void Start()
    {
        characterController = this.gameObject.GetComponent<CharacterController>();

        if (Instance is null)
        {
            Instance = this;
        }
    }

    void Update()
    {      
  
        PlayerRotation();
    }

    #region : Player Rotation
    private void PlayerRotation()
    {
        float horizontalInput = floatingJoystick.Horizontal;

        float verticalInput = floatingJoystick.Vertical;

        if (!isGround)
        {
            verticalVelocity = 0;
        }

        verticalVelocity -= stickToGroundForce * Time.deltaTime;

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        movementDirection.y = verticalVelocity;

        movementDirection.Normalize();

        characterController.Move(movementDirection * speed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    #endregion
}
