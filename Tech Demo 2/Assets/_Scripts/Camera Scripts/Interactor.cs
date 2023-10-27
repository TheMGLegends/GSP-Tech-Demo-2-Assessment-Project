using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Interactor : MonoBehaviour
{
    [Header("Interaction Settings:")]
    [SerializeField] private float interactionRange;

    private IInteractable previousInteractable;
    private bool isHovering;

    private void Update()
    {
        Ray raycast = new(transform.position, transform.forward);
        if (CanvasManager.instance.activeCanvas == CanvasManager.CanvasTypes.HUD && Physics.Raycast(raycast, out RaycastHit hitInfo, interactionRange))
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
