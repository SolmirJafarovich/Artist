using UnityEngine;

public class TriggerOnPickup : MonoBehaviour
{
    public string eventToSend;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameStateMachine>().TriggerEvent(eventToSend);
        }
    }
}
