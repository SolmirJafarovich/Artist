using UnityEngine;
using SojaExiles;

public class CameraCenterTrigger : MonoBehaviour
{
    public Camera mainCamera;  // Камера, из которой будем отправлять луч
    public float rayDistance = 100f;  // Дистанция, на которую будет отправляться луч
    public Transform Player;   // Трансформ игрока

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левый клик мыши
        {
            // Создаем луч из позиции мыши на экране
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // Преобразуем позицию центра экрана в мировые координаты
            Vector3 worldCenter = mainCamera.ScreenToWorldPoint(screenCenter);
            worldCenter.z = mainCamera.transform.position.z;  // Мы задаем z-координату, чтобы луч выходил из камеры

            // Создаем луч из центра экрана
            Ray ray = mainCamera.ScreenPointToRay(screenCenter);            RaycastHit hit;

            // Проверяем, пересекает ли луч какой-либо объект в сцене
            if (Physics.Raycast(ray, out hit))
            {
                // Если луч попал в объект с коллайдером
                if (hit.collider != null)
                {
                    OnObjectClick(hit.collider);
                }
            }
        }
    }
    private void OnObjectClick(Collider collider)
    {
        float distance = GetDistanceToPlayer(collider.gameObject);

        if (distance < 5)
        {
            if (collider.GetComponent<opencloseDoor>() != null)
            {
                opencloseDoor door = collider.GetComponent<opencloseDoor>();
                door.toggle();
            }
            else if (collider.GetComponent<ClosetopencloseDoor>() != null)
            {
                ClosetopencloseDoor door = collider.GetComponent<ClosetopencloseDoor>();
                door.toggle();
            }
        }
        
    }

    private float GetDistanceToPlayer(GameObject targetObject)
    {
        // Получаем позицию объекта и игрока
        Vector3 objectPosition = targetObject.transform.position;
        Vector3 playerPosition = Player.position;

        // Возвращаем расстояние между ними
        return Vector3.Distance(objectPosition, playerPosition);
    }
}


