using System;
using UnityEngine;
using UnityEngine.Events;

public class GuestRoom : MonoBehaviour, IInteractable
{
    [SerializeField]
    public UnityEvent OnGuestRoomEnter = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnGuestRoomEnter.Invoke();
    }
}
