using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Button useButton;
    [SerializeField] private Button discardButton;

    private void Start()
    {
        useButton.gameObject.SetActive(false);
        discardButton.gameObject.SetActive(false);
    }

    public void EnableButtons()
    {
        useButton.gameObject.SetActive(true);
        discardButton.gameObject.SetActive(true);
    }

    public void HighlightItem()
    {

    }
}
