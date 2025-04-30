using UnityEngine;

public class DoorbellService : MonoBehaviour
{
    [SerializeField]
    private AudioSource doorbellAudioSource;

    [SerializeField]
    private AudioClip doorbellClip;

    private void Awake()
    {
        Registry.Instance.Register(this);
    }

    public void Ring()
    {
        if (doorbellAudioSource == null)
        {
            Debug.LogWarning("DoorbellService: AudioSource is not assigned.");
            return;
        }

        if (doorbellClip == null)
        {
            Debug.LogWarning("DoorbellService: AudioClip is not assigned.");
            return;
        }

        doorbellAudioSource.PlayOneShot(doorbellClip);
    }

    public void SetClip(AudioClip clip)
    {
        doorbellClip = clip;
    }
}
