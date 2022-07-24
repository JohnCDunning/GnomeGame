using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance { get; private set; }
    public ItemFactory ItemFactory => itemFactory;

    [SerializeField] private ItemFactory itemFactory;
    [field: SerializeField] public InputController InputController { get; private set; } 
    
    private void Awake()
    {
        if (Instance)
            throw new Exception("Singleton Instance assigned twice ..");
        
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        Application.targetFrameRate = 60;

        Initialize();
    }

    private void Initialize()
    {
        InputController.Initialize();
        ItemFactory.Initialize();
    }
}
