using TMPro;
using UnityEngine;

public class ActionInteractMB : AbstractHudInteractMB
{
    [SerializeField] private TextMeshProUGUI actionText;

    protected override void onChangeTarget(IInteractable interactable)
    {
        if (interactable == null)
        {
            actionText.text = string.Empty;
        }
        else
        {
            actionText.text = interactable.Prompt;
        }
    }
}
