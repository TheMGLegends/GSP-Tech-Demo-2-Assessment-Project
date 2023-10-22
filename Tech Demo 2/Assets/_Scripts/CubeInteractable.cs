using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : MonoBehaviour, IInteractable
{
    private MeshRenderer meshRenderer;
    private int outlineMaterialIndex;

    private void Start()
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
        meshRenderer.materials[outlineMaterialIndex].SetFloat("_Scale", 1.03f);
        Debug.Log("Hey");
    }
    
    public void OnHoverExit()
    {
        meshRenderer.materials[outlineMaterialIndex].SetFloat("_Scale", 0);
        Debug.Log("Bye");
    }

    public void Interact()
    {
        Debug.Log("Looking at cube!");
    }
}
