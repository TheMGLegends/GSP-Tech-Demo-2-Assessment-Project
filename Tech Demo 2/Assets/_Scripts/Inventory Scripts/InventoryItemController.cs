using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Interactable item;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Button removeButton;
    [SerializeField] private TMP_Text itemName;

    public void AddItem(Interactable newItem)
    {
        item = newItem;
        itemIcon.sprite = item.GetItemSprite();
        itemIcon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        removeButton.interactable = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            OnMouseLeaveButton();
            SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.ItemUsed);
            item.GetItem().GetComponent<InteractableBaseClass>().Use();
            InventoryManager.Instance.Remove(item);
        }
    }

    public void RemoveItem()
    {
        OnMouseLeaveButton();
        InventoryManager.Instance.Remove(item);
    }

    public void OnMouseEnterButton()
    {
        if (item != null)
        {
            itemName.enabled = true;
            itemName.text = item.GetItemName();
        }
    }

    public void OnMouseLeaveButton()
    {
        if (item != null)
        {
            itemName.enabled = false;
        }
    }
}