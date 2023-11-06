using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Handles generic functions that all interactable objects have in common
/// </summary>
public abstract class InteractableBaseClass : MonoBehaviour
{
    [SerializeField] protected Interactable interactable;
    [SerializeField] protected TMP_Text interactionPromptText;

    protected MeshRenderer meshRenderer;
    protected int outlineMaterialIndex = -1;

    protected virtual void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        // INFO: Finds the outline material and makes note of its index in the materials array
        for (int i = 0; i < meshRenderer.materials.Length; i++)
        {
            if (meshRenderer.materials[i].name == "OutlineMaterial (Instance)")
            {
                outlineMaterialIndex = i;
            }
        }
    }

    public void OnHoverEnter()
    {
        if (outlineMaterialIndex != -1)
        {
            interactionPromptText.text = interactable.GetInteractionPrompt();
            // INFO: Outlines GOs mesh
            meshRenderer.materials[outlineMaterialIndex].SetFloat("_Scale", 1.03f);
        }
    }

    public void OnHoverExit()
    {
        if (outlineMaterialIndex != -1)
        {
            meshRenderer.materials[outlineMaterialIndex].SetFloat("_Scale", 0);
        }
    }

    public virtual bool Use() 
    {
        return false;
    }
}
