using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDoor : Interactable
{
    // Awake
    private void Awake()
    {
        Message = "Press [E] to Start Game";
    }

    // On Interact Function Override
    public override void OnInteract()
    {
        GameController.Instance.StartGame();
    }
}
