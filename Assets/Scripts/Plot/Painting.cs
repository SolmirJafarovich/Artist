using System;
using UnityEngine;
using UnityEngine.Events;

public class Painting : MonoBehaviour, IInteractable
{
    [SerializeField]
    public UnityEvent OnPaintingInteract = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnPaintingInteract.Invoke();
    }
}
