using UnityEngine;

public class PlayerHandMB : MonoBehaviour
{
    private AbstractGrabbableMB heldItem;

    public bool IsTool = false;

    public bool IsOccupied => heldItem != null;

    public void Grab(AbstractGrabbableMB prefab, bool isTool = false)
    {
        if (IsOccupied) return;

        IsTool = isTool;

        heldItem = Instantiate(prefab, transform);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;

        foreach (Collider col in heldItem.GetComponentsInChildren<Collider>())
            col.enabled = false;
    }

    public void UseHeldItem()
    {
        if (!IsOccupied || !heldItem.canInteract) return;

        heldItem.Interact();

        if(!IsTool)
            Destroy(heldItem.gameObject);

        heldItem = null;
    }

    public IInteractable GetInteractable()
    {
        return heldItem;
    }
}
