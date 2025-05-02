using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class Subtitle
{
    public string Key { get; set; }
    public string Text { get; set; }
}

public class SubtitlesService : MonoBehaviour
{
    [SerializeField] private TMP_Text subtitleText;
    [SerializeField] private string jsonFilePath = "Subtitles/content";
    [SerializeField] private float typingSpeed = 0.08f;

    private Dictionary<string, Subtitle> subtitlesDict;
    private Queue<string> subtitleQueue = new();
    private Coroutine processingCoroutine;
    private bool isShowing = false;

    public event Action OnSubtitleFinished;

    private HideService showUI;

    private void Awake()
    {
        Registry.Instance.Register(this);
        LoadSubtitles(jsonFilePath);
    }

    private void LoadSubtitles(string resourcePath)
    {
        TextAsset jsonAsset = Resources.Load<TextAsset>(resourcePath);
        if (jsonAsset == null)
        {
            Debug.LogError($"Subtitle JSON not found at Resources/{resourcePath}");
            return;
        }

        try
        {
            Subtitle[] subtitles = JsonConvert.DeserializeObject<Subtitle[]>(jsonAsset.text);
            subtitlesDict = new Dictionary<string, Subtitle>();
            foreach (var subtitle in subtitles)
                subtitlesDict[subtitle.Key] = subtitle;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error parsing subtitle JSON: {ex.Message}");
        }
    }

    public void ShowSubtitleByKey(string key)
    {
        if (subtitlesDict == null || !subtitlesDict.ContainsKey(key))
        {
            Debug.LogWarning($"Subtitle with key '{key}' not found.");
            return;
        }

        subtitleQueue.Enqueue(key);

        if (!isShowing)
            processingCoroutine = StartCoroutine(ProcessQueue());
    }

    private IEnumerator ProcessQueue()
    {
        isShowing = true;
        showUI = Registry.Instance.Get<HideService>();

        while (subtitleQueue.Count > 0)
        {
            string key = subtitleQueue.Dequeue();
            Subtitle subtitle = subtitlesDict[key];

            showUI.Subtitles(true);
            subtitleText.text = "";

            foreach (char c in subtitle.Text)
            {
                subtitleText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }

            OnSubtitleFinished?.Invoke();

            // Небольшая пауза между субтитрами (опционально)
            yield return new WaitForSeconds(1.0f);
        }

        isShowing = false;
    }
}

