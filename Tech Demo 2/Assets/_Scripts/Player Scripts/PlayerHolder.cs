using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject flashlight;

    private GameObject heldItem = null;
    Interactable item;

    private void Update()
    {
        if (heldItem != null)
        {
            if (item.GetItemType() == ItemType.Flashlight && Input.GetKeyDown(KeyCode.Mouse0) && CanvasManager.Instance.activeCanvas == CanvasManager.CanvasTypes.HUD)
            {
                SFXManager.Instance.PlaySoundEffect(SFXManager.SoundEffects.FlashlightOnOff);

                if (!heldItem.GetComponentInChildren<Light>().isActiveAndEnabled)
                {
                    heldItem.GetComponentInChildren<Light>().enabled = true;
                }
                else
                {
                    heldItem.GetComponentInChildren<Light>().enabled = false;
                }
            }
        }
    }

    public void PlayerHoldingItem(Interactable newItem)
    {
        ClearHeldItem();

        switch (newItem.GetItemType())
        {
            case ItemType.Axe:
                axe.SetActive(true);
                heldItem = axe;
                break;
            case ItemType.Flashlight:
                flashlight.SetActive(true);
                heldItem = flashlight;
                heldItem.GetComponentInChildren<Light>().enabled = false;
                break;
            case ItemType.Cube:
                break;
            case ItemType.Document:
                Debug.Log("Not pickupable!");
                break;
            case ItemType.Keypad:
                Debug.Log("Not pickupable!");
                break;
            default:
                break;
        }

        item = newItem;
    }

    public void ClearHeldItem()
    {
        if (heldItem != null)   
        {
            heldItem.SetActive(false);
            heldItem = null;
        }
    }
}
