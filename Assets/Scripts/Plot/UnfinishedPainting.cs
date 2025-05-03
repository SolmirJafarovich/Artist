using System;
using UnityEngine;
using UnityEngine.Events;

public class UnfinishedPainting : MonoBehaviour, IInteractable
{
    [SerializeField]
    public UnityEvent OnUnfinishedPaintingInteract = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnUnfinishedPaintingInteract.Invoke();
    }
}
