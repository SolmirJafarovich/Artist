using UnityEngine;
using System.Collections;
using DG.Tweening; // Для DOTween
using System.IO;

public class CutsceneService : MonoBehaviour
{
    private bool isCutscenePlaying = false;

    // Функция для начала катсцены
    public void StartCutscene(string cutsceneFolderName)
    {
        if (isCutscenePlaying) return; // Если катсцена уже идет, не начинаем новую
        StartCoroutine(PlayCutscene(cutsceneFolderName));
    }

    // Корутин для воспроизведения катсцены с использованием DOTween
    private IEnumerator PlayCutscene(string cutsceneFolderName)
    {
        isCutscenePlaying = true;
        
        // Загружаем все ресурсы из папки Resources
        string folderPath = Path.Combine("Cutscenes", cutsceneFolderName);
        Object[] cutsceneObjects = Resources.LoadAll(folderPath, typeof(GameObject));

        if (cutsceneObjects.Length == 0)
        {
            Debug.LogError($"Cutscene folder {cutsceneFolderName} is empty or does not exist!");
            isCutscenePlaying = false;
            yield break;
        }

        // Воспроизведение катсцены (например, последовательное включение объектов с анимациями DOTween)
        foreach (Object obj in cutsceneObjects)
        {
            GameObject cutsceneObject = obj as GameObject;

            if (cutsceneObject != null)
            {
                // Создаем объект в сцене
                GameObject instance = Instantiate(cutsceneObject);
                instance.SetActive(true);

                // Применяем DOTween анимации. Например, будем анимировать появление (увеличение масштаба)
                instance.transform.localScale = Vector3.zero; // Начальный размер 0

                // Анимируем объект с увеличением масштаба
                instance.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack);

                // Анимация альфа-канала для прозрачности (если у объекта есть Renderer с материалом)
                if (instance.GetComponent<Renderer>())
                {
                    instance.GetComponent<Renderer>().material.DOFade(1f, 1f).From(0f); // Плавно проявляется
                }

                // Задержка между объектами (время, на которое объект появляется)
                yield return new WaitForSeconds(1.5f); // Увеличьте или уменьшите по своему усмотрению
            }
        }

        // Завершаем катсцену
        isCutscenePlaying = false;
    }
}
