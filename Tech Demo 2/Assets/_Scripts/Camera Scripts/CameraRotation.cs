using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CameraRotation : MonoBehaviour
{
    [Header("Player Camera Settings:")]
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [Range(45, 90)] 
    [SerializeField] private float xRotationLimit;

    [Header("Player Transform:")]
    [SerializeField] private Transform playerOrientation;

    private float xRotation;
    private float yRotation;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        GetInputAxis();
        LookAround();
    }

    private void LookAround()
    {
        xRotation -= mouseY * xSensitivity * Time.deltaTime;
        yRotation += mouseX * ySensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);

        if (CanvasManager.instance.activeCanvas == CanvasManager.CanvasTypes.HUD)
        {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    private void GetInputAxis()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
    }
}
