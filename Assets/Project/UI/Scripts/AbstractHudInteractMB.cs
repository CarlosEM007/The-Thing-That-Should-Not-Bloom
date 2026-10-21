using UnityEngine;

public abstract class AbstractHudInteractMB : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerInteractMB playerInteract;

    private IInteractable currentTarget;

    private void OnEnable() => playerInteract.targetChanged += HandleTargetChanged;
    private void OnDisable() => playerInteract.targetChanged -= HandleTargetChanged;

    private void Update() => onChangeTarget(currentTarget);

    private void HandleTargetChanged(IInteractable interactable)
    {
        currentTarget = interactable;
        onChangeTarget(interactable);
    }

    protected virtual void onChangeTarget(IInteractable interactable) { }
}
