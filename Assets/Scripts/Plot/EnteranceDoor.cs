using UnityEngine;

public class EnteranceDoor : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInteract player)
    {
        GameObject held = player.GetHeldObject();

        if (held != null && held.GetComponent<KeyItem>() != null)
        {
            Debug.Log("? ���������� ������� � ����! ����� ����� ���� �������.");
        }
        else
        {
            Debug.Log("? �������� �������. �� ��������� ������� �����.");
        }
    }
}
