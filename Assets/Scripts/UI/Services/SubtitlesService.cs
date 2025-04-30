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
    [SerializeField] private string jsonFilePath = "Subtitles/content"; // Resources path (no extension)
    [SerializeField] private float typingSpeed = 0.08f; // seconds per character

    private Coroutine currentCoroutine;
    private Dictionary<string, Subtitle> subtitlesDict;

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
        showUI = Registry.Instance.Get<HideService>();
        showUI.Subtitles(true);

        Debug.Log($"subtitlesDict {subtitlesDict}");
        if (subtitlesDict == null || !subtitlesDict.ContainsKey(key))
        {
            Debug.LogWarning($"Subtitle with key '{key}' not found.");
            return;
        }

        Subtitle subtitle = subtitlesDict[key];

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(TypeText(subtitle.Text));
    }

    private IEnumerator TypeText(string fullText)
    {
        subtitleText.text = "";

        foreach (char c in fullText)
        {
            subtitleText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        OnSubtitleFinished?.Invoke();
    }
}
