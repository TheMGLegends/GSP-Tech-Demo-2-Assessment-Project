using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cube interactable object (more of a test object, but still shows how it functions so I kept it in the game)
/// </summary>
public class CubeInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with cube!");
        // INFO: If item is successfully added to inventory (returns true) then object can be deleted
        if (InventoryManager.Instance.Add(interactable))
            Destroy(gameObject);
    }

    public override bool Use()
    {
        Debug.Log("Used cube!");
        // INFO: If true returned means object will get used up (disappears from inventory)
        return true;
    }
}
