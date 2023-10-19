using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Looking at cube!");
    }
}
