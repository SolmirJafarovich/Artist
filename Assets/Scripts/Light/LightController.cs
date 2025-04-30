using UnityEngine;
using System.Collections.Generic;

public class LightController : MonoBehaviour
{
    [Header("Light & Emission Settings")]
    [Tooltip("Список всех источников света, которые будут включаться/выключаться")]
    public List<Light> lights = new List<Light>();

    [Tooltip("Объекты с материалами, у которых нужно управлять эмиссией")]
    public List<Renderer> emissiveRenderers = new List<Renderer>();

    [Tooltip("Цвет свечения при включенном свете")]
    public Color onEmissionColor = Color.white;

    [Tooltip("Цвет свечения при выключенном свете")]
    public Color offEmissionColor = Color.black;

    private List<Material> instanceMaterials = new List<Material>();
    private bool isOn = true;

    void Start()
    {
        // Создаём копии всех материалов, чтобы они были уникальными
        foreach (var renderer in emissiveRenderers)
        {
            if (renderer != null)
            {
                Material instancedMat = new Material(renderer.material);
                renderer.material = instancedMat;
                instanceMaterials.Add(instancedMat);
            }
        }

        ApplyState();
    }

    public void ToggleLight()
    {
        isOn = !isOn;
        ApplyState();
    }

    private void ApplyState()
    {
        // Включаем/выключаем все светильники
        foreach (var light in lights)
        {
            if (light != null)
                light.enabled = isOn;
        }

        // Меняем эмиссию на каждом материале
        foreach (var mat in instanceMaterials)
        {
            if (mat != null)
            {
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", isOn ? onEmissionColor : offEmissionColor);
            }
        }
    }
}
