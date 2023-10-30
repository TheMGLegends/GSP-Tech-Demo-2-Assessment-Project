using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Item", menuName = "ScriptableObjects/InteractableItem")]
public class InteractableItemScriptableObject : ScriptableObject
{
    public enum ItemType
    {
        Cube,
        Axe,
        Document,
        Flashlight,
        Keypad
    }

    [SerializeField] private string InteractionPrompt;
    [SerializeField] private ItemType itemType;
    [SerializeField] private string id;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;

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

    public ItemType GetItemType()
    {
        return itemType;
    }
}
