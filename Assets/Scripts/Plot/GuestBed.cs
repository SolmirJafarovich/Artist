using System;
using UnityEngine;
using UnityEngine.Events;

public class GuestBed : MonoBehaviour, IInteractable
{
    [SerializeField]
    public UnityEvent OnBedInteract = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnBedInteract.Invoke();
    }
}
