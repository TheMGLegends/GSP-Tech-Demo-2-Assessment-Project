using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Color highlightedColor;
    [SerializeField] private Material material;

    private Color startingColor;

    private void Start()
    {
        startingColor = material.GetColor("_BaseColor");
    }

    private void OnMouseEnter()
    {
        Debug.Log("Entered");
        material.SetColor("_BaseMap", highlightedColor);
        //meshRenderer.material.SetColor("_Color", highlightedColor);
    }

    private void OnMouseExit()
    {
        Debug.Log("Exited");
        material.SetColor("_BaseMap", startingColor);
        //meshRenderer.material.SetColor("_Color", startingColor);
    }
}
