using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with cube!");
        if (InventoryManager.Instance.Add(interactable))
            Destroy(gameObject);
    }

    public override bool Use()
    {
        Debug.Log("Used cube!");
        return true;
    }
}
