using UnityEngine;
using UnityEngine.Events;

public class BedroomDoor : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnBedRoomEnter = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnBedRoomEnter.Invoke();
    }
}