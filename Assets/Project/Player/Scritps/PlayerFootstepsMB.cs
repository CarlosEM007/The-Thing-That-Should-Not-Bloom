using UnityEngine;

public class PlayerFootstepsMB : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource stepSource;
    [SerializeField] private AudioClip[] stepClips;

    [Header("Rhythm")]
    [SerializeField] private float stepInterval = 0.5f;
    [SerializeField] private float minSpeed = 0.5f;

    [Header("Variation")]
    [SerializeField] private float minPitch = 0.9f;
    [SerializeField] private float maxPitch = 1.1f;

    private CharacterController characterController;
    private float stepTimer;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 velocity = characterController.velocity;
        velocity.y = 0f;

        bool walking = characterController.isGrounded && velocity.magnitude > minSpeed;

        if (!walking)
        {
            stepTimer = stepInterval;
            return;
        }

        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            PlayStep();
            stepTimer = 0f;
        }
    }

    private void PlayStep()
    {
        AudioClip clip = stepClips[Random.Range(0, stepClips.Length)];

        stepSource.pitch = Random.Range(minPitch, maxPitch);
        stepSource.PlayOneShot(clip);
    }
}
