using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTasksMB : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference openTasksInput;

    [Header("UI")]
    [SerializeField] private GameObject taskUI;

    [Header("Audio clip")]
    [SerializeField] private AudioClip paperOpen;

    private bool canUseAgain = true;

    private void OnEnable()
    {
        openTasksInput.action.performed += OpenTaskPaper;
        openTasksInput.action.Enable();
    }

    private void OnDisable()
    {
        openTasksInput.action.performed -= OpenTaskPaper;
        openTasksInput.action.Disable();
    }

    private void OpenTaskPaper(InputAction.CallbackContext context)
    {
        if (!canUseAgain) return;

        canUseAgain = false;

        taskUI.SetActive(!taskUI.activeSelf);
        AudioManagerMB.Instance.PlaySFX(paperOpen);

        StartCoroutine(SetActiveAgain());
    }

    private IEnumerator SetActiveAgain()
    {
        yield return new WaitForSeconds(1.5f);

        canUseAgain = true;
    }
}
