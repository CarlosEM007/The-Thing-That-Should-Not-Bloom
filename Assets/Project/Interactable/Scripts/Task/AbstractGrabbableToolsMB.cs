using System;
using UnityEngine;

public class AbstractGrabbableToolsMB : AbstractGrabbableMB
{
    [Header("Tool Info")]
    [SerializeField] protected ToolType toolType;
    [SerializeField] protected ToolState toolState;

    [Header("Player Hand")]
    [SerializeField] protected PlayerHandMB playerHand;

    public Action<bool, ToolType> OnObjectGrabbed;

    public override bool canInteract => true;

    public override void Interact()
    {
        if(toolState == ToolState.AtHand)
        {
            playerHand.Grab(this, true);
            toolState = ToolState.InHand;
        }
        else
        {
            OnObjectGrabbed.Invoke(true, toolType);
        }
    }
}
