using UnityEngine;
using UnityEngine.Events;

public class Knife : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnKnifeInteract = new UnityEvent();

    public void Interact(PlayerInteract player)
    {
        OnKnifeInteract.Invoke();
    }
}