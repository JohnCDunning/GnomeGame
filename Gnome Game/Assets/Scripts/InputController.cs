using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInputInstance;
    
    private GnomeGameActions gnomeGameActions;
    public void Initialize()
    {
        gnomeGameActions = new GnomeGameActions();
        gnomeGameActions.Player.Enable();
        playerInputInstance.ActivateInput();
    }

    public void SubscribePlayerInput(PlayerController playerController)
    {
        gnomeGameActions.Player.SetCallbacks(playerController);
    }
    
}
