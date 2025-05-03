using UnityEngine;

public class HideService : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]
    private GameObject dot;

    [SerializeField]
    private GameObject subtitles;

    [SerializeField]
    private GameObject history;

    [SerializeField]
    private GameObject cutscene;

    [SerializeField]
    private GameObject blur;

    private void Awake()
    {
        Registry.Instance.Register(this);
    }

    public void Dot(bool value) => dot.SetActive(value);

    public void Subtitles(bool value) => subtitles.SetActive(value);

    public void History(bool value) => history.SetActive(value);

    public void Cutscene(bool value) => cutscene.SetActive(value);

    public void Blur(bool value) => blur.SetActive(value);

    public void HideAllUI()
    {
        Dot(false);
        Subtitles(false);
        History(false);
        Cutscene(false);
    }

    public void Gameplay()
    {
        Dot(true);
        Subtitles(false);
        History(true);
        Cutscene(false);
    }
}
