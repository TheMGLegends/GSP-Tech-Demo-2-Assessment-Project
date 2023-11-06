using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Flashlight interactable object
/// </summary>
public class FlashlightInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with flashlight!");
        // INFO: If item is successfully added to inventory (returns true) then object can be deleted
        if (InventoryManager.Instance.Add(interactable))
            Destroy(gameObject);
    }

    public override bool Use()
    {
        Debug.Log("Equipped flashlight!");
        // INFO: If false returned means object won't get used up (won't disappear from inventory)
        return false;
    }
}
