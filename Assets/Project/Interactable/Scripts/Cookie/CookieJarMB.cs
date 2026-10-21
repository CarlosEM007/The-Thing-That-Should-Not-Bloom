using System;
using UnityEngine;

public class CookieJarMB : MonoBehaviour, IInteractable
{
    [Header("Reference")]
    [SerializeField] private AbstractGrabbableMB cookie;
    [SerializeField] private PlayerHandMB playerHand;

    [Header("Interaction")]
    [SerializeField] private string prompt = "Take a cookie";

    private int cookieInJar = 3;

    public string Prompt
    {
        get => prompt;
        set => prompt = value;
    }

    public bool canInteract => cookieInJar > 0 && !playerHand.IsOccupied;

    public void Interact()
    {
        playerHand.Grab(cookie);
        cookieInJar--;

        if (cookieInJar == 0) prompt = "The jar is empty.";
    }
}
