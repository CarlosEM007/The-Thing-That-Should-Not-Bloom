using Assets.Project.UI.Scripts.Enum;
using UnityEngine;
using UnityEngine.UI;

public class CenterIconMB : AbstractHudInteractMB
{
    [Header("Sprites")]
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        ApplyState(CenterIconState.Inactive);
    }

    protected override void onChangeTarget(IInteractable interactable)
    {
        bool active = interactable != null && interactable.canInteract;
        ApplyState(active ? CenterIconState.Active : CenterIconState.Inactive);
    }

    private void ApplyState(CenterIconState state)
    {
        image.sprite = state == CenterIconState.Active ? activeSprite : inactiveSprite;
    }
}
