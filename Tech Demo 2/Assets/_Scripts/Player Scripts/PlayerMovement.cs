using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings:")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float groundDrag;

    [Header("Orientation:")]
    [SerializeField] private Transform playerOrientation;

    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = groundDrag;
    }

    private void Update()
    {
        GetInputAxis();
        OpenInventory();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movementDirection = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;

        if (CanvasManager.instance.activeCanvas == CanvasManager.CanvasTypes.HUD)
        {
            rb.AddForce(movementDirection.normalized * movementSpeed, ForceMode.Force);
        }
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && CanvasManager.instance.activeCanvas == CanvasManager.CanvasTypes.HUD)
        {
            CanvasManager.instance.ShowCanvas(CanvasManager.CanvasTypes.InventoryView);
        }
        else if (Input.GetKeyDown(KeyCode.I) && CanvasManager.instance.activeCanvas == CanvasManager.CanvasTypes.InventoryView) {
            CanvasManager.instance.ShowCanvas(CanvasManager.CanvasTypes.HUD);
        }
    }

    private void GetInputAxis()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}
