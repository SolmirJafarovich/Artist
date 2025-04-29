using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactDistance = 4.5f;
    public Transform holdPoint;

    private GameObject heldObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // œ Ã
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

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;
    }

    public void DropHeldObject()
    {
        if (heldObject == null) return;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;

        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
