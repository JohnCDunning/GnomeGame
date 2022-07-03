using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, GnomeGameActions.IPlayerActions
{
    public CharacterController controller;
    public float playerMoveSpeed = 5;
    private Vector3 movement;
    private Vector3 lastMovement;

    private Vector3 cyanBallPos;
    private Vector3 offset = Vector3.up;
    public float maxOffset = 1;
    public float offsetSpeed;
    public float cameraSpeed;
    public float rotationSpeed = 1000;
    public CameraController CameraController;

    public WeaponBase activeWeapon;

    public Blackboard fsmBlackBoard;
    public FSMOwner fsmOwner;
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
        if(lastMovement != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lastMovement, Vector3.up), rotationSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector3 vel = new Vector3();
        CameraController.transform.position = Vector3.SmoothDamp(CameraController.transform.position, cyanBallPos, ref vel, cameraSpeed);
    }

    private void FixedUpdate()
    {
        Vector3 movementLastFrame = movement;
        controller.Move(movement * Time.fixedDeltaTime * playerMoveSpeed);

        if (movement != Vector3.zero)
        {
           lastMovement = movement.normalized;
           fsmBlackBoard.SetVariableValue("isWalking", true);
        }
        else
        {
            fsmBlackBoard.SetVariableValue("isWalking", false);
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
        if (activeWeapon)
            activeWeapon.Attack(this.transform);
    }
}