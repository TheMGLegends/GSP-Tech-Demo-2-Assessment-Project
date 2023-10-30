using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class InteractableBaseClass : MonoBehaviour
{
    [SerializeField] protected InteractableItemScriptableObject itemScriptableObject;
    [SerializeField] protected TMP_Text interactionPromptText;

    protected MeshRenderer meshRenderer;
    protected int outlineMaterialIndex = -1;

    protected void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

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
            interactionPromptText.text = itemScriptableObject.GetInteractionPrompt();
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
}
