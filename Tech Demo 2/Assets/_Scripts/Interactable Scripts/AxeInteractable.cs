using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with axe!");
    }
}