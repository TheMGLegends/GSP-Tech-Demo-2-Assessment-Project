using UnityEngine;

public enum ItemType
{
    Axe,
    Flashlight,
    Cube,
    Document,
    Keypad
}

[CreateAssetMenu(fileName = "New Interactable Item", menuName = "ScriptableObjects/Interactable")]
public class Interactable : ScriptableObject
{
    [SerializeField] private string InteractionPrompt;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private GameObject item;
    [SerializeField] private ItemType itemType;

    public string GetInteractionPrompt()
    {
        return InteractionPrompt;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public Sprite GetItemSprite()
    {
        return itemSprite;
    }

    public GameObject GetItem()
    {
        if (item != null)
        {
            return item;
        }
        else
        {
            return null;
        }
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
}
