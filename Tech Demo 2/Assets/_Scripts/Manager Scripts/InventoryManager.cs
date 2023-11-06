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
    [SerializeField] private TMP_Text fullText;
    [SerializeField] private float fullNotificationDelay;

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

    public bool Add(Interactable item)
    {
        if (items.Count < inventorySpace)
        {
            items.Add(item);

            ListItems();
            return true;
        }
        else
        {
            StartCoroutine(DisplayFullTextCoroutine(fullNotificationDelay));
        }
        return false;
    }

    public void Remove(Interactable item)
    {
        items.Remove(item);

        ListItems();

        if (heldItem != null)
        {
            if (heldItem == item)
            {
                playerHolder.ClearHeldItem();
                heldItem = null;
            }
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

    public Interactable GetHeldItem()
    {
        return heldItem;
    }

    private IEnumerator DisplayFullTextCoroutine(float delay)
    {
        fullText.enabled = true;
        yield return new WaitForSeconds(delay);
        fullText.enabled = false;
    }
}
