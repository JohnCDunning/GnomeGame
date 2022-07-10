using System.Collections;
using System.Collections.Generic;
using NodeCanvas.BehaviourTrees;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractive
{
    public BehaviourTreeOwner behaviourTreeOwner;
    public void Interact()
    {
        WorldManager.instance.playerController.CameraController.isInteracting = true;
        behaviourTreeOwner.StartBehaviour();
    }
    public Transform GetTransform()
    {
        return transform;
    }
}
