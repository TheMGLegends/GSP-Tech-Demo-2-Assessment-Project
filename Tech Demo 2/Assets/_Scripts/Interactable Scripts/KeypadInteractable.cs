using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeypadInteractable : InteractableBaseClass, IInteractable
{
    [SerializeField] private GameObject keypadCamera;

    private BoxCollider boxCollider;
    private bool isBoxActive = true;

    protected override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void Interact()
    {
        Debug.Log("Interacting with keypad!");
        CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.KeypadView);
        boxCollider.enabled = false;
        isBoxActive = false;
        CameraManager.Instance.SetCurrentCamera(keypadCamera);
    }

    private void Update()
    {
        if (keypadCamera.GetComponent<Camera>().enabled == false && !isBoxActive)
        {
            boxCollider.enabled = true;
            isBoxActive = true;
            Debug.Log("Camera change yes");
        }
    }
}
