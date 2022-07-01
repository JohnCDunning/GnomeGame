using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, GnomeGameActions.IPlayerActions
{
    public CharacterController controller;
    public Vector3 movement;
    public Vector3 lastMovement;

    public Vector3 cyanBallPos;
    public Vector3 offset = Vector3.up;
    public float maxOffset;
    public float offsetSpeed;
    public float rotationSpeed = 1000;
    public CameraController CameraController;



    public void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        AppManager.Instance.InputController.SubscribePlayerInput(this);
    }

    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lastMovement, Vector3.up), rotationSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector3 vel = new Vector3();
        CameraController.transform.position = Vector3.SmoothDamp(CameraController.transform.position, cyanBallPos, ref vel, 1f);
    }

    private void FixedUpdate()
    {
        Vector3 movementLastFrame = movement;
        controller.Move(movement * Time.fixedDeltaTime * 3);

        if (movement != Vector3.zero)
        {
        
           lastMovement = movement.normalized;
        }

        
        //Camera controller for smooth offset
        offset += movement * (offsetSpeed * Time.deltaTime);
        offset = Vector3.ClampMagnitude(offset, maxOffset);
        cyanBallPos = transform.position + offset;
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(cyanBallPos,0.3f);
        Gizmos.DrawLine(transform.position,cyanBallPos);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        movement = new Vector3(direction.x, 0, direction.y);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }
}
