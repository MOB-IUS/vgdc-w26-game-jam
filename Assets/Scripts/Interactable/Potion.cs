using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Potion : Interactable
{
    // Member variables
    private float _amplitude = 0.25f;
    private float _speed = 0.5f;
    private float _currPos;
    
    
    
    // Awake
    private void Awake()
    {
        _currPos = -_amplitude;
        Message = "Press [E] to Collect";
    }

    // Update
    private void Update()
    {
        // Move potion upside down
        float displacement = _speed * Time.deltaTime;
        _currPos += displacement;
        if (_currPos >= _amplitude || _currPos <= -_amplitude)
        {
            _speed = -_speed;
        }
        
        transform.position = new Vector3(transform.position.x, transform.position.y + displacement, 
            transform.position.z);
    }

    // OnInteract
    public override void OnInteract()
    {
        GameController.Instance.CurrScore += 1;
        PlayerLocater.Instance.GetPlayerTransform().gameObject.
            GetComponent<PlayerController>().UpdateScore(GameController.Instance.CurrScore);
        GameController.Instance.GenerateNewPotion();
        
        Destroy(gameObject);
    }
}
