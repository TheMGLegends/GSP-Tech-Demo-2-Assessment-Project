using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with flashlight!");
    }
}