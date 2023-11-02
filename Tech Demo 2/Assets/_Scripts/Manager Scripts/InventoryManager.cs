using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private int inventorySpace;
    [SerializeField] private List<Interactable> items = new();
    [SerializeField] private Transform itemContent;
    [SerializeField] private InventoryItemController[] inventoryItems;

    [SerializeField] private PlayerHolder playerHolder;

    private Interactable heldItem = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();
    }

    public void Add(Interactable item)
    {
        if (items.Count < inventorySpace)
        {
            items.Add(item);

            ListItems();
        }
    }

    public void Remove(Interactable item)
    {
        items.Remove(item);

        ListItems();

        if (heldItem != null)
        {
            playerHolder.ClearHeldItem();
            heldItem = null;
        }
    }

    public void ListItems()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (i < items.Count)
            {
                inventoryItems[i].AddItem(items[i]);
            }
            else
            {
                inventoryItems[i].ClearSlot();
            }
        }
    }

    public void SetHeldItem(Interactable item)
    {
        if (heldItem != item)
        {
            heldItem = item;
            playerHolder.PlayerHoldingItem(heldItem);
        }
        else
        {
            heldItem = null;
            playerHolder.ClearHeldItem();
        }
    }
}
