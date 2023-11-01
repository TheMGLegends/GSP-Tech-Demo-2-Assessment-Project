using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public interface IInteractable
{
    void OnHoverEnter();
    void OnHoverExit();
    void Interact();
    void Use();
}
