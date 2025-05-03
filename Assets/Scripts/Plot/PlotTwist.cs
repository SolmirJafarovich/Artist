using System;
using UnityEngine;
using UnityEngine.Events;

public class PlotTwist : MonoBehaviour, IInteractable
{
    [SerializeField]
    public PlotEvent evt;

    public void Interact(PlayerInteract player)
    {
        EventBus.StateChanged(evt);
    }
}
