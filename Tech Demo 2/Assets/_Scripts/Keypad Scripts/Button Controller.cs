using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Color highlightedColor;
    [SerializeField] private Color pressedColor;
    [SerializeField] private int buttonID;

    private KeypadInteractable interactable;
    private MeshRenderer materialObject;
    private Color startingColor;

    private bool canClick = true;
    private bool isClicked = false;

    private void Start() 
    {
        if (transform.parent.parent != null)
        {
            interactable = transform.parent.parent.GetComponent<KeypadInteractable>();
        }

        materialObject = GetComponent<MeshRenderer>();
        startingColor = materialObject.material.color;
    }

    private void OnMouseOver()
    {
        if (!isClicked && canClick)
        {
            materialObject.material.color = highlightedColor;
        }
    }

    private void OnMouseDown()
    {
        if (canClick)
        {
            isClicked = true;
            materialObject.material.color = pressedColor;
            interactable.AddInput(buttonID);
        }
    }

    private void OnMouseUp()
    {
        if (canClick)
        {
            isClicked = false;
        }
    }

    private void OnMouseExit()
    {
        if (canClick)
        {
            isClicked = false;
            materialObject.material.color = startingColor;
        }
    }

    private void Update()
    {
        if (interactable.IsInputLocked() && canClick)
        {
            materialObject.material.color = startingColor;
            canClick = false;
        }
        else if (!interactable.IsInputLocked() && !canClick)
        {
            canClick = true;
        }
    }
}
