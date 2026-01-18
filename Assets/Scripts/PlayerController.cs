using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Member variables
    private Rigidbody _rb;
    [SerializeField]private Transform _mainCameraTransform;
    
    private float _speed = 5.0f;        // Player Movement
    private float _sensitivity = 10f;
    private float _xOrientation = 0f;
    private float _yOrientation = 0f;
    private Vector3 _inputDirection;

    
    
    // Awake
    private void Awake()
    {
        // Initialization
        _rb = GetComponent<Rigidbody>();
        
        // Lock Curser
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Player Look
        _yOrientation = Math.Clamp(_yOrientation, -90f, 90f);
        _mainCameraTransform.transform.rotation = Quaternion.Euler(-_yOrientation, _xOrientation, 0f);
        
        // Player Movement
        _rb.velocity = (Quaternion.Euler(0f, _xOrientation, 0f) * _inputDirection).normalized * _speed;
    }

    // Update player velocity
    void OnMove(InputValue value)
    {
        _inputDirection = value.Get<Vector3>();
    }

    // Update player looking direcitons
    void OnLook(InputValue value)
    {
        Vector2 look = value.Get<Vector2>();
        _xOrientation += look.x * _sensitivity * Time.deltaTime;
        _yOrientation += look.y * _sensitivity * Time.deltaTime;
    }
}
