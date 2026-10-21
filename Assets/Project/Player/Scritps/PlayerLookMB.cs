using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLookMB : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference lookAction;

    [Header("Reference")]
    [SerializeField] private Transform playerCamera;

    [Header("Player Info")]
    [SerializeField] private PlayerInfoSO playerInfo;

    private float pitch;

    private void OnEnable()
    {
        lookAction.action.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        lookAction.action.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        Vector2 delta = lookAction.action.ReadValue<Vector2>() * playerInfo.sensitivity;

        transform.Rotate(Vector3.up, delta.x);

        pitch -= delta.y;
        pitch = Mathf.Clamp(pitch, -playerInfo.limitPitch, playerInfo.limitPitch);
        playerCamera.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
