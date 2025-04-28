using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Newtonsoft.Json;

public class Subtitle
{
    public string Key { get; set; }
    public string Text { get; set; }
    public float DelayBeforeStart { get; set; }
    public float Duration { get; set; }
}

public class SubtitlesManager : MonoBehaviour
{
    public TMP_Text subtitleText;  // TextMeshPro для вывода субтитров
    private Coroutine currentCoroutine;
    private Queue<Subtitle> subtitlesQueue;

    void Start()
    {
        Debug.Log("Loading content.json");
        LoadSubtitles("Assets/Scripts/UI/Subtitles/content.json");
    }

    // Загружаем и парсим данные из файла JSON
    private void LoadSubtitles(string filePath)
    {
        string jsonContent = File.ReadAllText(filePath);
        subtitlesQueue = new Queue<Subtitle>(JsonConvert.DeserializeObject<Subtitle[]>(jsonContent));
    }

    // Запуск субтитров с указанным ключом
    public void ShowSubtitleByKey(string key)
    {
        Subtitle subtitle = GetSubtitleByKey(key);
        if (subtitle != null)
        {
            // Останавливаем текущую корутину, если она есть
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);

            currentCoroutine = StartCoroutine(ShowTextCoroutine(subtitle));
        }
    }

    // Получение субтитров по ключу
    private Subtitle GetSubtitleByKey(string key)
    {
        foreach (Subtitle subtitle in subtitlesQueue)
        {
            if (subtitle.Key == key)
                return subtitle;
        }
        return null;
    }

    // Показ текста с постепенным появлением
    private IEnumerator ShowTextCoroutine(Subtitle subtitle)
    {
        // Задержка перед началом отображения
        yield return new WaitForSeconds(subtitle.DelayBeforeStart);

        subtitleText.text = "";
        string[] lines = SplitTextIntoLines(subtitle.Text);

        // Показ текста построчно, чтобы не более 3 строк на экране
        foreach (string line in lines)
        {
            subtitleText.text += line + "\n";
            yield return new WaitForSeconds(subtitle.Duration / lines.Length);
        }

        yield return new WaitForSeconds(subtitle.Duration); // Задержка перед скрытием текста
        subtitleText.text = "";  // Очищаем текст
    }

    // Разбиение текста на строки с максимальной длиной (например, 30 символов)
    private string[] SplitTextIntoLines(string text)
    {
        string[] words = text.Split(' ');
        string currentLine = "";
        var lines = new System.Collections.Generic.List<string>();

        foreach (var word in words)
        {
            // Если слово слишком длинное (больше 30 символов), разбиваем его
            if (word.Length > 30)
            {
                lines.Add(word);  // Добавляем слово на новую строку
            }
            else if ((currentLine + " " + word).Length < 30)  // Проверка длины строки
            {
                currentLine += " " + word;
            }
            else
            {
                lines.Add(currentLine.Trim());
                currentLine = word;
            }
        }

        if (currentLine.Length > 0)
            lines.Add(currentLine.Trim());

        return lines.ToArray();
    }
}
