using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlurService : MonoBehaviour
{
    public PostProcessVolume volume;

    private bool blurEnabled = false;

    private void Awake() {
        Registry.Instance.Register(this);
    }

    private void Start()
    {
        if (volume == null)
        {
            Debug.LogError("PostProcessVolume reference is missing!");
            return;
        }
        ShowBlur(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            blurEnabled = !blurEnabled;
            ShowBlur(blurEnabled);
        }
    }

    public void ShowBlur(bool is_active)
    {
        volume.enabled = is_active;
    }
}
