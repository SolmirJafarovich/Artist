using UnityEngine;
using System.Collections.Generic;

public class LightController : MonoBehaviour
{
    [Header("Light & Emission Settings")]
    [Tooltip("������ ���� ���������� �����, ������� ����� ����������/�����������")]
    public List<Light> lights = new List<Light>();

    [Tooltip("������� � �����������, � ������� ����� ��������� ��������")]
    public List<Renderer> emissiveRenderers = new List<Renderer>();

    [Tooltip("���� �������� ��� ���������� �����")]
    public Color onEmissionColor = Color.white;

    [Tooltip("���� �������� ��� ����������� �����")]
    public Color offEmissionColor = Color.black;

    private List<Material> instanceMaterials = new List<Material>();
    private bool isOn = true;

    void Start()
    {
        // ������ ����� ���� ����������, ����� ��� ���� �����������
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
        // ��������/��������� ��� �����������
        foreach (var light in lights)
        {
            if (light != null)
                light.enabled = isOn;
        }

        // ������ ������� �� ������ ���������
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
