using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class Interactable for all interactable object types
public abstract class Interactable : MonoBehaviour
{
    public abstract void OnInteract();
    public string Message { get; set; }
}
