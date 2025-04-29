using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using System.IO;

public class CutsceneService : MonoBehaviour
{
    [SerializeField] private Image slideshowImage;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image blackBackground;

    private List<Sprite> slides = new();
    private int currentSlideIndex = 0;
    private bool isCutscenePlaying = false;

    private void Awake()
    {
        Registry.Instance.SetCutsceneService(this);
        Debug.Log("CutsceneService awaked and registered");

        // Ensure black background is fully black and covers screen
        if (blackBackground != null)
        {
            blackBackground.color = Color.black;
            blackBackground.gameObject.SetActive(false);
        }

        canvasGroup.alpha = 0f;
        slideshowImage.enabled = false;
    }

    public void Init(string folderName)
    {
        if (isCutscenePlaying) return;

        string path = Path.Combine("Cutscenes", folderName);
        slides = new List<Sprite>(Resources.LoadAll<Sprite>(path));

        if (slides.Count == 0)
        {
            Debug.LogError($"No slides found in: {path}");
            return;
        }

        isCutscenePlaying = true;
        currentSlideIndex = 0;

        // Enable black background
        if (blackBackground != null)
            blackBackground.gameObject.SetActive(true);

        // Показываем первый слайд
        NextSlide();
    }

    public void NextSlide()
    {
        if (!isCutscenePlaying || slides.Count == 0) return;

        if (currentSlideIndex < slides.Count)
        {
            Sprite nextSlide = slides[currentSlideIndex];
            slideshowImage.sprite = nextSlide;

            // Fade-in animation
            slideshowImage.enabled = true;
            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1f, 0.8f);
        }

        currentSlideIndex++;

        // Если слайды закончились
        if (currentSlideIndex >= slides.Count)
        {
            Stop();
        }
    }

    public void Stop()
    {
        isCutscenePlaying = false;
        slides.Clear();
        currentSlideIndex = 0;

        canvasGroup.alpha = 0f;
        slideshowImage.enabled = false;

        // Отключаем черный фон
        if (blackBackground != null)
            blackBackground.gameObject.SetActive(false);
    }
}
