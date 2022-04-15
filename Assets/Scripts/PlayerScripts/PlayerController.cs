using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public static PlayerController Instance;

    #region Movement Values
    private CharacterController characterController;

    [SerializeField]
    private float stickToGroundForce = 9.8f;

    [SerializeField]
    private float verticalVelocity;

    [SerializeField]
    private FloatingJoystick floatingJoystick;

    public float speed;

    private Vector3 movementDirection;

    private float horizontalInput;
    
    private float verticalInput;

    #endregion

    private void Start()
    {
        characterController = this.gameObject.GetComponent<CharacterController>();

        if (Instance is null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
         horizontalInput = floatingJoystick.Horizontal;

         verticalInput = floatingJoystick.Vertical;

        JoystickController();
    }
    void FixedUpdate()
    {


        GravityCheck();

    }

    #region : Gravity Check
    private void GravityCheck()
    {
        verticalVelocity -=stickToGroundForce * Time.deltaTime;

        movementDirection.y = verticalVelocity;

        characterController.Move(movementDirection * Time.deltaTime);

    }
    #endregion

    #region : JoystickControl
    private void JoystickController()
    {
        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        
        characterController.Move(movementDirection * speed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection);

            this.transform.rotation = toRotation;
        }
    }
    #endregion
}
