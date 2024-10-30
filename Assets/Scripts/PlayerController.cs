using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Camera playerCamera;

    private float yRotation = 0f;
    private PlayerControls controls;

    private void OnEnable()
    {
        controls = new PlayerControls();
        controls.Gameplay.Enable();
        controls.Gameplay.Look.performed += OnLook;
        controls.Gameplay.Look.canceled += OnLook;
    }

    private void OnDisable()
    {
        controls.Gameplay.Look.performed -= OnLook;
        controls.Gameplay.Look.canceled -= OnLook;
        controls.Gameplay.Disable();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;
        playerCamera.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
