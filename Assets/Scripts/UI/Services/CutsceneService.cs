using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;
using System.Collections.Generic;
using System;
using System.Collections;
using TMPro;
using Newtonsoft.Json;

public class CutsceneService : MonoBehaviour
{
    [SerializeField] private Image slideshowImage;

    private List<Sprite> slides = new();
    private int currentSlideIndex = 0;

    [SerializeField] private TMP_Text subtitleText;
    [SerializeField] private string jsonFilePath = "Subtitles/content"; // Resources path (no extension)
    [SerializeField] private float typingSpeed = 0.08f; // seconds per character

    private Coroutine currentCoroutine;
    private Dictionary<string, Subtitle> subtitlesDict;

    private void Awake()
    {
        Registry.Instance.Register(this);
        slideshowImage.enabled = false;
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
    }

    public void Init(string folderName)
    {
        string path = Path.Combine("Cutscenes", folderName);
        slides = new List<Sprite>(Resources.LoadAll<Sprite>(path));

        if (slides.Count == 0)
        {
            Debug.LogError($"No slides found in: {path}");
            return;
        }

        currentSlideIndex = 0;
    }

    public bool NextSlide()
    {
        if (currentSlideIndex < slides.Count)
        {
            Sprite nextSlide = slides[currentSlideIndex];
            slideshowImage.sprite = nextSlide;
            ShowSubtitleByKey(nextSlide.name);

            // Fade-in animation
            slideshowImage.enabled = true;
            currentSlideIndex++;

            return true;
        }
        else
        {
            Stop();

            return false;
        }
    }

    public void Stop()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }

        slideshowImage.DOKill();

        // Clear UI and state
        subtitleText.text = "";
        slides.Clear();
        currentSlideIndex = 0;
        slideshowImage.enabled = false;
    }
}
