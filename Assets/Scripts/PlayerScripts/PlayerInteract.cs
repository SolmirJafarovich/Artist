using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactDistance = 4.5f;
    public Transform holdPoint;

    private GameObject heldObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ���
        {
            if (IsInteractableInFront(out IInteractable interactable))
            {
                interactable.Interact(this);
            }
            else if (heldObject != null)
            {
                DropHeldObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
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

        // ��������� ������
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.detectCollisions = false; // ��������� ������������
        }

        Collider col = heldObject.GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true; // �������� ������
        }
    }

    public void DropHeldObject()
    {
        if (heldObject == null) return;

        // �������� ������
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
            print("you are pickup object");
        }

        Collider col = heldObject.GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = false;
        }

        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    private bool IsInteractableInFront(out IInteractable interactable)
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            interactable = hit.collider.GetComponent<IInteractable>();
            return interactable != null;
        }

        interactable = null;
        return false;
    }


    private void UseHeldObject()
    {
        if (heldObject == null) return;

        IInteractable interactable = heldObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact(this);
        }
        else
        {
            Debug.Log("Held object does not implement IInteractable.");
        }
    }

    public GameObject GetHeldObject()
    {
        return heldObject;
    }

    public void ClearHeldObject()
    {
        heldObject = null;
    }

}

