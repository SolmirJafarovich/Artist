using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BlurService : MonoBehaviour
{
    public PostProcessVolume volume;
    private DepthOfField dof;

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
    }

    public void ShowBlur(bool is_active)
    {
        if (dof == null) return;

        dof.active = is_active;
        dof.focusDistance.value = 0.1f; // Closer focus = more blur for background
        dof.aperture.value = 32f;       // Higher aperture = shallower depth of field
        dof.focalLength.value = 50f;    // Can also play with this
    }
}
