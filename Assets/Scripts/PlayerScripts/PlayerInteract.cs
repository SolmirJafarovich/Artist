using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactDistance = 4.5f;
    public Transform holdPoint;

    private GameObject heldObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ПКМ
        {
            if (heldObject == null)
                TryInteract();
            else
                DropHeldObject();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(this);
            }
        }
    }

    public void HoldObject(GameObject obj)
    {
        if (heldObject != null)
            DropHeldObject();

        heldObject = obj;
        heldObject.transform.SetParent(holdPoint);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;

        // Отключаем физику
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.detectCollisions = false; // Отключает столкновения
        }

        Collider col = heldObject.GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true; // Проходит сквозь
        }
    }

    public void DropHeldObject()
    {
        if (heldObject == null) return;

        // Включаем физику
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }

        Collider col = heldObject.GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = false;
        }

        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
