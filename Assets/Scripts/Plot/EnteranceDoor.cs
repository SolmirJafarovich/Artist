using UnityEngine;

public class EnteranceDoor : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteract player)
    {
        GameObject held = player.GetHeldObject();

        if (held != null && held.GetComponent<KeyItem>() != null)
        {
            Debug.Log("? Правильный предмет в руке! Дверь может быть открыта.");
        }
        else
        {
            Debug.Log("? Неверный предмет. Не получится открыть дверь.");
        }
    }
}
