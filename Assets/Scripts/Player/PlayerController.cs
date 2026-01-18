using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Member variables
    private Rigidbody _rb;
    [SerializeField]private Transform _mainCameraTransform;
    
    private float _speed = 13.5f;                // Player Movement
    private float _sensitivity = 10f;
    private float _xOrientation = 0f;
    private float _yOrientation = 0f;
    private Vector3 _inputDirection;
    
    private float _interactDistance = 3.5f;     // Player Interact
    private Interactable _interactable;
    [SerializeField] private GameObject _promptMessage;
    [SerializeField] private TMP_Text _scoreNum;

    
    
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
        
        // Player Interact
        Ray ray = new Ray(_mainCameraTransform.position, _mainCameraTransform.forward);
        RaycastHit hit;

        // Find interactable object
        if (Physics.Raycast(ray, out hit, _interactDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                _interactable = hit.collider.gameObject.GetComponent<Interactable>();
                _promptMessage.GetComponent<TMP_Text>().text = _interactable.Message;
                _promptMessage.SetActive(true);
            }
        }
        else   // NOT Find interactable object
        {
            _interactable = null;
            _promptMessage.GetComponent<TMP_Text>().text = "";
            _promptMessage.SetActive(false);
        }
    }
    
    // Return _xOrientation
    public float GetXOrientation()
    {
        return _xOrientation;
    }
    
    // Update score text
    public void UpdateScore(int score)
    {
        _scoreNum.text = score.ToString();
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
    
    // Player interact
    void OnInteract(InputValue value)
    {
        if (_interactable != null)
        {
            Debug.Log("Player interacts!");
            _interactable.OnInteract();
        }
    }
}
