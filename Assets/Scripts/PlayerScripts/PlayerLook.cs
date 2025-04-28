using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // �������� ������ � ��������� ��� � ������
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // ������� �����/���� (������)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ����������� �����/����

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // ������� �����/������ (�����)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
