using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class PlayerInteractor : MonoBehaviour
{
    [Header("Interaction Settings:")]
    [SerializeField] private float interactionRange;

    private IInteractable previousInteractable;
    private bool isHovering;

    private void Update()
    {
        InteractWithObject();
        InteractWithInventory();
        InteractWithKeypad();
    }


    private void InteractWithObject()
    {
        Ray raycast = new(transform.position, transform.forward);
        if (CanvasManager.Instance.activeCanvas == CanvasManager.CanvasTypes.HUD && Physics.Raycast(raycast, out RaycastHit hitInfo, interactionRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                if (previousInteractable != interactable)
                {
                    interactable.OnHoverEnter();
                    previousInteractable = interactable;
                    isHovering = true;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    ClearInteractionOutline();
                    interactable.Interact();
                }
            }
            else if (previousInteractable != null)
            {
                ClearInteractionOutline();
            }
        }
        else if (previousInteractable != null)
        {
            ClearInteractionOutline();
        }
    }

    private static void InteractWithInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && CanvasManager.Instance.activeCanvas == CanvasManager.CanvasTypes.HUD)
        {
            CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.InventoryView);
        }
        else if (Input.GetKeyDown(KeyCode.X) && CanvasManager.Instance.activeCanvas == CanvasManager.CanvasTypes.InventoryView)
        {
            CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.HUD);
        }
    }

    private void InteractWithKeypad()
    {
        if (Input.GetKeyDown(KeyCode.X) && CanvasManager.Instance.activeCanvas == CanvasManager.CanvasTypes.KeypadPrompts)
        {
            CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.HUD);
            CameraManager.Instance.SetCurrentCamera(CameraManager.Instance.GetPlayerCamera());
        }
    }

    private void ClearInteractionOutline()
    {
        previousInteractable.OnHoverExit();
        previousInteractable = null;
        isHovering = false;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);
    }

    public bool IsHovering()
    {
        return isHovering;
    }
}
