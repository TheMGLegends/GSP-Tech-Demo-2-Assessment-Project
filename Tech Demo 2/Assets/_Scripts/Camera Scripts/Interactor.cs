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

    private void Update()
    {
        Ray raycast = new Ray(transform.position, transform.forward);
        IInteractable interactable = null;

        if (Physics.Raycast(raycast, out RaycastHit hitInfo, interactionRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out interactable))
            {
                if (previousInteractable != interactable)
                {
                    interactable.OnHoverEnter();
                    previousInteractable = interactable;
                }
            }
        }
        else if (previousInteractable != null)
        {
            previousInteractable.OnHoverExit();
            previousInteractable = null;
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);
    }
}
