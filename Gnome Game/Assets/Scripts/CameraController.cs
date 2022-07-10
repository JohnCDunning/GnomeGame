using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;

    public float offset;
    public float speed; 
   
    private Vector3 velocity;
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, playerController.transform.position, ref velocity, speed);
    }
}
