using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the players movement
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
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movementDirection = playerOrientation.forward * verticalInput + playerOrientation.right * horizontalInput;

        // INFO: Only allows movement when the hud canvas is active
        if (CanvasManager.Instance.activeCanvas == CanvasManager.CanvasTypes.HUD)
        {
            rb.AddForce(movementDirection.normalized * movementSpeed, ForceMode.Force);
        }
    }

    private void GetInputAxis()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}
