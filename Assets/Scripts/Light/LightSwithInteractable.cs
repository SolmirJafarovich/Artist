using UnityEngine;

public class LightSwitchInteractable : MonoBehaviour, IInteractable
{
    public LightController lightController;

    public void Interact(PlayerInteract player)
    {
        if (lightController != null)
            lightController.ToggleLight();
    }
}
