using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 movement;
    public Vector3 lastMovement;

    public Vector3 cyanBallPos;
    public Vector3 offset;
    public float maxOffset;
    public float offsetSpeed;

    public CameraController CameraController;
    private void FixedUpdate()
    {
        Vector3 movementLastFrame = movement;
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) ;

        controller.Move(movement * Time.fixedDeltaTime * 3);

        if (movement != Vector3.zero)
        {
           transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
          
            lastMovement = movement.normalized;
        }

        
        //Camera controller for smooth offset
        offset += movement * (offsetSpeed * Time.deltaTime);
        offset = Vector3.ClampMagnitude(offset, maxOffset);
        cyanBallPos = transform.position + offset;

        CameraController.transform.position = cyanBallPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(cyanBallPos,0.3f);
        Gizmos.DrawLine(transform.position,cyanBallPos);
    }
}
