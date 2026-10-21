using UnityEngine;

public class PlayerHandMB : MonoBehaviour
{
    private AbstractGrabbableMB heldItem;

    public bool IsOccupied => heldItem != null;

    public void Grab(AbstractGrabbableMB prefab)
    {
        if (IsOccupied) return;

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
        Destroy(heldItem.gameObject);
        heldItem = null;
    }

    public IInteractable GetInteractable()
    {
        return heldItem;
    }
}
