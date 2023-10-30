using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    InteractableItemScriptableObject itemScriptableObject;
    public Button removeButton;

    public void RemoveItem()
    {
        InventoryManager.instance.Remove(itemScriptableObject);

        Destroy(gameObject);
    }

    public void AddItem(InteractableItemScriptableObject newItem)
    {
        itemScriptableObject = newItem;
    }

    public void UseItem()
    {
        SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.ItemUsed);

        RemoveItem();
    }
}
