using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance { get; private set; }

    [field: SerializeField] public InputController InputController { get; private set; } 
    
    private void Awake()
    {
        if (Instance)
            throw new Exception("Singleton Instance assigned twice ..");
        
        Instance = this;
        DontDestroyOnLoad(this.gameObject);



        Initialize();
    }

    private void Initialize()
    {
        InputController.Initialize();   
    }
}
