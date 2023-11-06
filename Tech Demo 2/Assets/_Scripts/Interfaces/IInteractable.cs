using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for interactable objects, the following functions must be implemented
/// </summary>
public interface IInteractable
{
    void OnHoverEnter();
    void OnHoverExit();
    void Interact();
    bool Use();
}
