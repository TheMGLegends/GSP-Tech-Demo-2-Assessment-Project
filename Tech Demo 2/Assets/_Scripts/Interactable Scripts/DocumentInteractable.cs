using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Document interactable object
/// </summary>
public class DocumentInteractable : InteractableBaseClass, IInteractable
{
    [SerializeField] private string documentText;
    private TMP_Text displayText;

    protected override void Start()
    {
        base.Start();
        displayText = GetComponentInChildren<TMP_Text>();
        displayText.text = documentText;

    }

    public void Interact()
    {
        Debug.Log("Interacting with document!");
        // INFO: Shows a different canvas as a result of interacting with the GO
        CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.DocumentView);
        // INFO: Access the specified GO using CanvasTypes enum and sets the contents of document
        CanvasManager.Instance.AccessCanvasGO(CanvasManager.CanvasTypes.DocumentView).GetComponent<DocumentViewingController>().SetDocumentContentsText(documentText);
    }

    public void SetDocumentText(string text)
    {
        documentText = text;
    }
}
