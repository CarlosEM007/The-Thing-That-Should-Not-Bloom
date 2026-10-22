using System;
using UnityEngine;

public class PlantsTaskMB : MonoBehaviour, IInteractable
{
    [Header("State")]
    [SerializeField] private PlantsStateEnum plantState;

    [Header("Reference")]
    [SerializeField] private AbstractGrabbableToolsMB wateringCan;
    [SerializeField] private AbstractGrabbableToolsMB sickle;
    [SerializeField] private AbstractGrabbableToolsMB seeds;

    public Action<PlantsStateEnum> taskDoneEvent;

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

    private void OnDisable()
    {
        wateringCan.OnObjectGrabbed -= ValidateInteraction;
        sickle.OnObjectGrabbed -= ValidateInteraction;
        seeds.OnObjectGrabbed -= ValidateInteraction;
    }

    private void Start()
    {
        StateChanges();
    }

    public void Interact()
    {
        taskDoneEvent?.Invoke(plantState);
        NextStage();

        _canInteract = false;
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
            case PlantsStateEnum.Done:
                prompt = "Just await!";
                return;
        }
    }

    private void ValidateInteraction(bool inHand, ToolType type)
    {
        bool validate = false;

        if (!inHand)
        {
            _canInteract = validate;
            return;
        }

        switch (type)
        {
            case ToolType.Seed:
                if (plantState == PlantsStateEnum.Seed)
                    validate = true;
                break;
            case ToolType.Sickle:
                if (plantState == PlantsStateEnum.Harvest)
                    validate = true;
                break;
            case ToolType.Watering:
                if (plantState == PlantsStateEnum.Water)
                    validate = true;
                break;
        }

        _canInteract = validate;
    }

    private void NextStage()
    {
        switch (plantState)
        {
            case PlantsStateEnum.Seed:
                plantState = PlantsStateEnum.Water;
                break;
            case PlantsStateEnum.Water:
                plantState = PlantsStateEnum.Done;
                break;
            case PlantsStateEnum.Harvest:
                plantState = PlantsStateEnum.Seed;
                break;
        }

        StateChanges();
    }
}
