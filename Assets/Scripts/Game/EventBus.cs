using System;

public enum PlotEvent
{
    OnBedRoomEnter,
    OnKnifeInteract,
    OnWorkshopEnter,
    OnGuestRoomEnter,
    OnBedInteract,
    OnPaintingInteract,
    OnUnfinishedPaintingInteract,
    OnEntranceDoorClick,
}

public static class EventBus
{
    public static event Action<PlotEvent> OnStateChanged;

    public static void StateChanged(PlotEvent newState)
    {
        OnStateChanged?.Invoke(newState);
    }
}
