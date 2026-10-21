using UnityEngine;

public class PlantsTaskMB : MonoBehaviour, IInteractable
{
    [Header("State")]
    [SerializeField] private PlantsStateEnum plantState;

    private string prompt;

    public string Prompt
    {
        get => prompt;
        set => prompt = value;
    }

    public bool canInteract => ;

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
}
