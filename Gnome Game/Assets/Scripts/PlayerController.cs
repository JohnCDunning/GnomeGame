using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, GnomeGameActions.IPlayerActions
{
   
   
    [ReadOnly,BoxGroup("Debug"), SerializeField] private Vector3 movement;
    [ReadOnly,BoxGroup("Debug"), SerializeField] private Vector3 lastMovement;
    [ReadOnly,BoxGroup("Debug"), SerializeField] Vector3 cyanBallPos;
    [ReadOnly,BoxGroup("Debug"), SerializeField] private Vector3 offset = Vector3.zero;
    
    [Title("PlayerController Settings")]
    [SerializeField] public CharacterController controller;
    [SerializeField] private float maxOffset;
    [SerializeField] private float offsetSpeed;
    [SerializeField] private float cameraSpeed = 0.001f;
    [SerializeField] private float playerSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5;
    public CameraController CameraController;
    public WeaponBase activeWeapon;


    
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
        if (lastMovement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lastMovement, Vector3.up), rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        Vector3 movementLastFrame = movement;
        controller.Move(movement * (Time.deltaTime * playerSpeed));

        if (movement != Vector3.zero)
        {
            lastMovement = movement.normalized;
        }
    }

    private void LateUpdate()
    {
        ///Vector3 vel = new Vector3();
        ///CameraController.transform.position = Vector3.SmoothDamp(CameraController.transform.position, cyanBallPos, ref vel, cameraSpeed);
    }

    private void FixedUpdate()
    {


        
       // //Camera controller for smooth offset
       // offset += movement * (offsetSpeed * Time.deltaTime);
       // offset = Vector3.ClampMagnitude(offset, maxOffset);
       // cyanBallPos = transform.position + offset;
        
    }

    ///private void OnDrawGizmos()
    ///{
    ///    Gizmos.color = Color.cyan;
    ///    Gizmos.DrawSphere(cyanBallPos,0.3f);
    ///    Gizmos.DrawLine(transform.position,cyanBallPos);
    ///}
    
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