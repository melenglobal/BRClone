using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    public Transform camera;

    [SerializeField]
    private FloatingJoystick floatingJoystick;
    [SerializeField]
    private DynamicJoystick dynamicJoystick;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField] 
    private float _turnSmoothTime = 0.1f;

    private float _turnSmoothVelocity;
    
    
    private bool groundedPlayer;
    

    private void Start()
    {
        controller = this.gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
   

        Vector3 direction = new Vector3(floatingJoystick.Horizontal, 0, floatingJoystick.Vertical).normalized;

        if (direction.magnitude > 0.1f)
        {   
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref _turnSmoothVelocity,_turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f,targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * _moveSpeed * Time.deltaTime); // frame rate independet
        }
        


    }
}
