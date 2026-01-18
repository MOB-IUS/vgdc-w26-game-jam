using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocater : MonoBehaviour
{
    // Singleton
    private static PlayerLocater _instance;
    public static PlayerLocater Instance { get { return _instance; } }
    
    
    
    // Awake
    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        // Initialization
        _instance = this;
    }
    
    // Return player transform
    public Transform GetPlayerTransform()
    {
        return this.gameObject.transform;
    }
}
