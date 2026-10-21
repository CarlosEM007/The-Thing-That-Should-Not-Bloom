using UnityEngine;

public class AbstractGrabbableMB : MonoBehaviour, IInteractable
{
    protected string prompt;

    public virtual string Prompt
    {
        get => prompt;
        set => prompt = value;
    }

    public virtual bool canInteract => false;

    public virtual void Interact() { return; }
}
