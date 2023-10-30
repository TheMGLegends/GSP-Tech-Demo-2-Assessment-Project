using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField] private List<InteractableItemScriptableObject> items = new();
    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private InventoryItemController[] inventoryItems;
    [SerializeField] private Toggle EnableRemove;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Add(InteractableItemScriptableObject item)
    {
        items.Add(item);
    }

    public void Remove(InteractableItemScriptableObject item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject GO = Instantiate(inventoryItem, itemContent);
            var itemName = GO.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = GO.transform.Find("Icon").GetComponent<Image>();
            var removeButton = GO.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.GetItemName();
            itemIcon.sprite = item.GetItemSprite();

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }

        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
