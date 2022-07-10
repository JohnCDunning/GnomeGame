using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    private PlayerController playerController;

    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera interactCamera;
    public float offset;
    public float speed; 
   
    private Vector3 velocity;

    public bool isInteracting = false;
    public void Init(PlayerController player)
    {
        playerController = player;
        normalCamera.LookAt = playerController.transform;
        player.CameraController = this;
    }
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, playerController.transform.position, ref velocity, speed);
        if (isInteracting)
        {
            normalCamera.gameObject.SetActive(false);
            interactCamera.gameObject.SetActive(true);
        }
        else
        {
            normalCamera.gameObject.SetActive(true);
            interactCamera.gameObject.SetActive(false);
        }
    }
}
