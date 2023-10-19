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

    private void Update()
    {
        Ray raycast = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(raycast, out RaycastHit hitInfo, interactionRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactableObject))
            {
                // Temporary Test:
                interactableObject.Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);
    }
}
