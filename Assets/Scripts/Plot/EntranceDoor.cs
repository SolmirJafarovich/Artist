using System;
using UnityEngine;
using UnityEngine.Events;

public class EntranceDoor : MonoBehaviour, IInteractable
{
    [SerializeField]
    public UnityEvent OnEntranceDoorClick = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnEntranceDoorClick.Invoke();
    }
}
