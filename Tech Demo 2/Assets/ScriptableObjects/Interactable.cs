using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Item", menuName = "ScriptableObjects/Interactable")]
public class Interactable : ScriptableObject
{
    [SerializeField] private string InteractionPrompt;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private GameObject item;

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
        return item;
    }
}
