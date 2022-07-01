using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;

    public float offset;
    public float speed; 
    void Update()
    {
       // transform.position = Vector3.MoveTowards(transform.position,
           // playerController.transform.position + (playerController.lastMovement * offset), Time.deltaTime * speed);


    }
}
