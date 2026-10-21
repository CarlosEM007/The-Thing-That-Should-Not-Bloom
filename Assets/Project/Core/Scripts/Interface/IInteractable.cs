public interface IInteractable
{
    string Prompt { get; set; }
    bool canInteract { get; }
    void Interact();
}
