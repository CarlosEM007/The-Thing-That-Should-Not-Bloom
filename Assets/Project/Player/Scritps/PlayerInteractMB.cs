using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractMB : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference interactAction;

    [Header("Reference")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private PlayerHandMB playerHand;

    [Header("Playe Info")]
    [SerializeField] private PlayerInfoSO playerInfo;

    private IInteractable currentTarget;

    public event Action<IInteractable> targetChanged;

    private void OnEnable()
    {
        interactAction.action.Enable();
        interactAction.action.performed += Interact;
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
        interactAction.action.performed -= Interact;
    }

    private void Update()
    {
        IInteractable newTarget = SearchTarget();

        if (playerHand.IsOccupied && (newTarget == null || !newTarget.canInteract) && !playerHand.IsTool)
            newTarget = playerHand.GetInteractable();

        if (newTarget == currentTarget)
            return;

        currentTarget = newTarget;
        targetChanged?.Invoke(currentTarget);
    }

    private IInteractable SearchTarget()
    {
        Vector3 origen = playerCamera.position;
        Vector3 direction = playerCamera.forward;

        Debug.DrawLine(origen, direction * playerInfo.interactDistance, Color.red);

        if (!Physics.Raycast(origen, direction, out RaycastHit hit, playerInfo.interactDistance,
                            playerInfo.mask, QueryTriggerInteraction.Ignore))
        {
            return null;
        }

        return hit.collider.GetComponentInParent<IInteractable>();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (!ValidTarget() || !currentTarget.canInteract)
            return;

        if (playerHand.IsOccupied && currentTarget == playerHand.GetInteractable())
        {
            playerHand.UseHeldItem();
            return;
        }

        currentTarget.Interact();
    }

    private bool ValidTarget() => currentTarget is UnityEngine.Object obj && obj != null;
}
