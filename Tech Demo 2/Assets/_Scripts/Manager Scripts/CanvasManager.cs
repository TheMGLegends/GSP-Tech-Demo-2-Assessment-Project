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

    public static CanvasManager Instance;

    [Header("Canvases:")]
    [SerializeField] private Canvas startingCanvas;
    [SerializeField] private List<CanvasTypes> canvasTypesList = new();
    [SerializeField] private List<Canvas> canvasList = new();

    private Dictionary<CanvasTypes, Canvas> canvasDictionary = new();
    public CanvasTypes activeCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
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

    public void ShowCanvas(CanvasTypes canvasToShow)
    {
        if (canvasDictionary.ContainsKey(canvasToShow))
        {
            canvasDictionary[activeCanvas].gameObject.SetActive(false);
            canvasDictionary[canvasToShow].gameObject.SetActive(true);
            activeCanvas = canvasToShow;
        }
        else
        {
            Debug.Log("Canvas type not found!");
        }
    }

    public GameObject AccessCanvasGO(CanvasTypes currentCanvas)
    {
        return canvasDictionary[currentCanvas].gameObject;
    }
}
