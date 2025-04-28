using System.Collections;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI subtitlesText; // ссылка на текст субтитров
    public GameObject historyPanel; // панель истории сообщений
    public GameObject glasses; // объект очков (если нужен)
    private bool glassesOn = true;

    private string fullSubtitle = ""; // полный текст субтитров
    private Coroutine typingCoroutine;

    void Update()
    {
        // Надевать/снимать очки по E
        if (Input.GetKeyDown(KeyCode.E))
        {
            glassesOn = !glassesOn;
            glasses.SetActive(glassesOn);
        }

        // Открывать/закрывать историю сообщений по H
        if (Input.GetKeyDown(KeyCode.H))
        {
            historyPanel.SetActive(!historyPanel.activeSelf);
        }
    }

    // Плавная печать субтитров
    public void ShowSubtitle(string text, float typingSpeed = 0.05f)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeSubtitle(text, typingSpeed));
    }

    private IEnumerator TypeSubtitle(string text, float typingSpeed)
    {
        fullSubtitle = text;
        subtitlesText.text = "";
        foreach (char c in text)
        {
            subtitlesText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
