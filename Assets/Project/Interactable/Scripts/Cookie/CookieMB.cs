using UnityEngine;

public class CookieMB : AbstractGrabbableMB
{
    [Header("Audio")]
    [SerializeField] private AudioClip eatSound;

    public override string Prompt => "Eat the cookie.";

    public override bool canInteract => true;

    public override void Interact()
    {
        AudioManagerMB.Instance.PlaySFX(eatSound, 2);
    }
}
