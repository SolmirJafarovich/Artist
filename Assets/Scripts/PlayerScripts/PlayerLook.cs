using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // Скрываем курсор и фиксируем его в центре
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Вращаем вверх/вниз (камера)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ограничение вверх/вниз

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Вращаем влево/вправо (игрок)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
