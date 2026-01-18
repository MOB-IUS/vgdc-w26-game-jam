using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Singleton
    private static CameraController _instance;
    public static CameraController Instance { get { return _instance; } }
    
    // Member variables
    [SerializeField] private GameObject _mapCamera;
    [SerializeField] private GameObject _playerCamera;
    
    
    
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
    
    // Switch to Map Camera
    public void ChangeToMapCamera()
    {
        _playerCamera.SetActive(false);
        _mapCamera.SetActive(true);
    }
    
    // Switch to Player Camera
    public void ChangeToPlayerCamera()
    {
        _mapCamera.SetActive(false);
        _playerCamera.SetActive(true);
    }
}
