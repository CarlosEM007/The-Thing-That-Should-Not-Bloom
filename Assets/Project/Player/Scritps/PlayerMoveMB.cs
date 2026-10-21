using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveMB : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference walkAction;

    [Header("Player Info")]
    [SerializeField] private PlayerInfoSO playerInfo;

    private CharacterController characterController;
    private float verticalSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable() => walkAction.action.Enable();
    private void OnDisable() => walkAction.action.Disable();

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = walkAction.action.ReadValue<Vector2>();

        Vector3 direction = transform.forward * input.y + transform.right * input.x;
        Vector3 displacement = direction * playerInfo.speed;

        if (characterController.isGrounded && verticalSpeed < 0f)
            verticalSpeed = playerInfo.stayGroundForce;

        verticalSpeed += playerInfo.gravity * Time.deltaTime;

        characterController.Move(displacement * Time.deltaTime);
    }
}
