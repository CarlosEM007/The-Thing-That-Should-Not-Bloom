using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerInfoSO : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] public float speed = 3.5f;
    [SerializeField] public float gravity = -20f;
    [SerializeField] public float stayGroundForce = -2f;

    [Header("Sensitivity")]
    [SerializeField] public float sensitivity = 0.1f;
    [SerializeField] public float limitPitch = 0.1f;

    [Header("Interact")]
    [SerializeField] public float interactDistance = 2f;
    [SerializeField] public LayerMask mask = ~0;
}
