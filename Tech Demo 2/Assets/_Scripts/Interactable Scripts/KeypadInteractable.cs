using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with keypad!");
    }
}
