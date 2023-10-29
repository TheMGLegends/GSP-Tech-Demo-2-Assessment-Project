using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public enum CanvasTypes
    {
        HUD,
        DocumentView,
        InventoryView
    }

    public static CanvasManager instance;

    [Header("Canvases:")]
    [SerializeField] private Canvas startingCanvas;
    [SerializeField] private List<CanvasTypes> canvasTypesList = new();
    [SerializeField] private List<Canvas> canvasList = new();

    private Dictionary<CanvasTypes, Canvas> canvasDictionary = new();
    public CanvasTypes activeCanvas;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < canvasList.Count; i++)
        {
            if (canvasList[i] != startingCanvas)
            {
                canvasList[i].gameObject.SetActive(false);
            }
            else
            {
                activeCanvas = canvasTypesList[i];
            }

            canvasDictionary.Add(canvasTypesList[i], canvasList[i]);
        }
    }

    private void DisableAllCanvases()
    {
        for (int i = 0; i < canvasList.Count; i++)
        {
            canvasList[i].gameObject.SetActive(false);
        }
    }

    public void ShowCanvas(CanvasTypes canvasToShow)
    {
        DisableAllCanvases();

        for (int i = 0; i < canvasDictionary.Count; i++)
        {
            if (canvasDictionary.ContainsKey(canvasToShow))
            {
                canvasDictionary[canvasToShow].gameObject.SetActive(true);
                activeCanvas = canvasToShow;
            }
        }
    }

    public GameObject AccessCanvasGO(CanvasTypes currentCanvas)
    {
        return canvasDictionary[currentCanvas].gameObject;
    }
}
