using System;
using System.Collections.Generic;
using UnityEngine;

public enum PlotItem
{
    EntranceDoor,
    Lamp,
    AlarmPhone,
    CutsceneIntro,
    SubtitleOpening
}

[Serializable]
public class PlotItemEntry
{
    public PlotItem item;
    public GameObject gameObject;
}

public class ItemService : MonoBehaviour
{
    [SerializeField] private List<PlotItemEntry> items;

    private Dictionary<PlotItem, GameObject> _itemMap;

    private void Awake()
    {
        BuildItemMap();
        Registry.Instance.Register(this);
    }

    private void BuildItemMap()
    {
        _itemMap = new Dictionary<PlotItem, GameObject>();

        foreach (var entry in items)
        {
            if (_itemMap.ContainsKey(entry.item))
                throw new Exception($"Duplicate PlotItem: {entry.item} in ItemsService");

            _itemMap[entry.item] = entry.gameObject;
        }

        // Optional: Check for missing items
        foreach (PlotItem plotItem in Enum.GetValues(typeof(PlotItem)))
        {
            if (!_itemMap.ContainsKey(plotItem))
            {
                Debug.LogWarning($"Missing GameObject for PlotItem: {plotItem}");
            }
        }
    }

    public GameObject this[PlotItem item]
    {
        get
        {
            if (_itemMap.TryGetValue(item, out var go))
                return go;

            Debug.LogError($"PlotItem not found: {item}");
            return null;
        }
    }
}