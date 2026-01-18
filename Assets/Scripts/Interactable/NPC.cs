using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : Interactable
{
    // Member variables
    private int _nextIndex = 0;
    private float _currTime = 0f;
    private float _maxTime = 7f;

    private string[] _messageList =
    {
        "Go get me some blue magic potions!",
        "I will share map marking your and potion's posions with you everytime a new potion appears, BUT only 10s every time.",
        "But I have to rest for 30s to share the map before you get to the potion.",
        "Good Luck!"
    };
    [SerializeField] private TMP_Text _message;
    
    
    
    // Awake
    private void Awake()
    {
        Message = "Press [E] to Talk";
    }


    public override void OnInteract()
    {
        _message.text = _messageList[_nextIndex++];
        if (_nextIndex >= 4)
        {
            _nextIndex = 0;
        }

        _currTime = _maxTime;
    }

    // Update
    private void Update()
    {
        if (_message.text != "")
        {
            _currTime -= Time.deltaTime;
            if (_currTime <= 0f)
            {
                _message.text = "";
            }   
        }
    }
}
