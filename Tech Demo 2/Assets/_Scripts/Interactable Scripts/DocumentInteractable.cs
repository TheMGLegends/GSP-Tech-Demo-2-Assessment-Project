using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        CanvasManager.Instance.ShowCanvas(CanvasManager.CanvasTypes.DocumentView);
        CanvasManager.Instance.AccessCanvasGO(CanvasManager.CanvasTypes.DocumentView).GetComponent<DocumentViewingController>().SetDocumentContentsText(documentText);
    }
}
