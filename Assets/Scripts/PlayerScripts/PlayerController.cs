using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private CharacterController characterController;

    public Transform transformCamera;

    [SerializeField]
    private FloatingJoystick floatingJoystick;

    [SerializeField]
    private DynamicJoystick dynamicJoystick;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField] 
    private float _turnSmoothTime = 0.1f;

    private float _turnSmoothVelocity;
    
    
    private bool isGround;
    

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
        isGround = characterController.isGrounded;

        PlayerRotation();
    }

    #region : Player Rotation
    private void PlayerRotation()
    {
        var direction = new Vector3(dynamicJoystick.Horizontal, 0, dynamicJoystick.Vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + transformCamera.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDirection.normalized * _moveSpeed * Time.deltaTime); // frame rate independet
        }
    }
    #endregion
}
