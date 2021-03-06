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
    public Transform weaponAttachPoint;



    public List<IInteractive> interactivesNearbyeList = new List<IInteractive>();
    public void Start()
    {
        Initialize();

        if (activeWeapon)
        {
            activeWeapon.Attach(weaponAttachPoint, this.gameObject);
        }
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

    private IInteractive GetClosestInteractive()
    {
        float bestDistance = 100;
        IInteractive closestInteractive = null;
        for (int i = 0; i < interactivesNearbyeList.Count; i++)
        {
            float dist = Vector3.Distance(interactivesNearbyeList[i].GetTransform().position, transform.position);
            if(dist<bestDistance)
            {
                bestDistance = dist;
                closestInteractive = interactivesNearbyeList[i];
            }
        }
        CameraController.interactCamera.m_LookAt = closestInteractive?.GetTransform();
        return closestInteractive;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractive interactive))
        {
            if (!interactivesNearbyeList.Contains(interactive))
            {
                interactivesNearbyeList.Add(interactive);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractive interactive))
        {
            if (interactivesNearbyeList.Contains(interactive))
            {
                interactivesNearbyeList.Remove(interactive);
            }
        }
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
        if (activeWeapon && context.started)
            activeWeapon.Attack(this.transform.forward);
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
            GetClosestInteractive()?.Interact();
    }
}
