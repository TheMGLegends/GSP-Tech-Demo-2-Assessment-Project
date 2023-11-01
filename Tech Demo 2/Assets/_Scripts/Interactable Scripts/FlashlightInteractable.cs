using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with flashlight!");
        InventoryManager.Instance.Add(interactable);
        Destroy(gameObject);
    }

    public override void Use()
    {
        Debug.Log("Used flashlight!");
    }
}
