using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Interactable itemScriptableObject;
    public Button removeButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(itemScriptableObject);

        Destroy(gameObject);
    }

    public void AddItem(Interactable newItem)
    {
        itemScriptableObject = newItem;
    }

    public void UseItem()
    {
        SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.ItemUsed);

        RemoveItem();
    }
}
