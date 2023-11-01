using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentInteractable : InteractableBaseClass, IInteractable
{
    [SerializeField] private string documentText;

    public void Interact()
    {
        Debug.Log("Interacting with document!");
        CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.DocumentView);
        CanvasManager.Instance.AccessCanvasGO(CanvasManager.CanvasTypes.DocumentView).GetComponent<DocumentViewingController>().SetDocumentContentsText(documentText);
    }
}
