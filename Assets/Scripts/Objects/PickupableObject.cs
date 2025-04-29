using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PickupableObject : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteract player)
    {
        player.HoldObject(gameObject);
    }
}
