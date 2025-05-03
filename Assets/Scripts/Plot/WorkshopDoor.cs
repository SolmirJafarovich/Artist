using UnityEngine;
using UnityEngine.Events;
public class WorkshopDoor : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnWorkshopEnter = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnWorkshopEnter.Invoke();
    }
}