using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with cube!");
        InventoryManager.Instance.Add(interactable);
        Destroy(gameObject);
    }
}
