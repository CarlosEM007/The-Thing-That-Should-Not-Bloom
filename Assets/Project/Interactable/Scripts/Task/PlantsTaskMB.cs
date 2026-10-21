using UnityEngine;

public class PlantsTaskMB : MonoBehaviour, IInteractable
{
    [Header("State")]
    [SerializeField] private PlantsStateEnum plantState;

    [Header("Reference")]
    [SerializeField] private GrabbableToolsMB wateringCan;
    [SerializeField] private GrabbableToolsMB sickle;
    [SerializeField] private GrabbableToolsMB seeds;

    private string prompt;

    public string Prompt
    {
        get => prompt;
        set => prompt = value;
    }

    public bool canInteract => _canInteract;
    private bool _canInteract;

    private void OnEnable()
    {
        wateringCan.OnObjectGrabbed += ValidateInteraction;
        sickle.OnObjectGrabbed += ValidateInteraction;
        seeds.OnObjectGrabbed += ValidateInteraction;
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    private void StateChanges()
    {
        switch (plantState)
        {
            case PlantsStateEnum.Seed:
                prompt = "Plant the seeds";
                return;
            case PlantsStateEnum.Water:
                prompt = "Water the plants";
                return;
            case PlantsStateEnum.Harvest:
                prompt = "Harvest the plants";
                return;
        }
    }

    private void ValidateInteraction(bool inHand, ToolType type)
    {
        bool validate = false;

        switch (type)
        {
            case ToolType.Seed:
                if (plantState == PlantsStateEnum.Seed && inHand)
                    validate = true;
                break;
            case ToolType.Sickle:
                if (plantState == PlantsStateEnum.Harvest && inHand)
                    validate = true;
                break;
            case ToolType.Watering:
                if (plantState == PlantsStateEnum.Water && inHand)
                    validate = true;
                break;
        }

        _canInteract = validate;
    }
}
