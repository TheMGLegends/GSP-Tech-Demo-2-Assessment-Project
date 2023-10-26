using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Item", menuName = "ScriptableObjects/InteractableItem")]
public class InteractableItemScriptableObject : ScriptableObject
{
    public enum ItemType
    {
        Cube,
        Axe,
        Document,
        Flashlight
    }

    [SerializeField] private string InteractionPrompt;
    [SerializeField] private ItemType itemType;

    public string GetInteractionPrompt()
    {
        return InteractionPrompt;
    }
}
