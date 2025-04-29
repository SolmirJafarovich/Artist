using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PictureSwapper : MonoBehaviour, IInteractable
{
    [SerializeField] private Texture[] textures;
    private int currentIndex = 0;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();

        if (textures.Length > 0)
            rend.material.mainTexture = textures[currentIndex];
    }

    public void Interact(PlayerInteract player)
    {
        if (textures.Length < 2) return;

        currentIndex = (currentIndex + 1) % textures.Length;
        rend.material.mainTexture = textures[currentIndex];
    }
}
