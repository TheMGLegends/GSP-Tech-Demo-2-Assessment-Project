using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeInteractable : InteractableBaseClass, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacting with axe!");
        InventoryManager.Instance.Add(interactable);
        Destroy(gameObject);
    }

    public override void Use()
    {
        Debug.Log("Used axe!");
    }
}
