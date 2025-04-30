using System;
using System.Collections.Generic;
using UnityEngine;

public class Registry : MonoBehaviour
{
    private static Registry _instance;
    public static Registry Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("Registry");
                _instance = obj.AddComponent<Registry>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    private readonly Dictionary<Type, object> _services = new();

    // Регистрация сервиса
    public void Register<T>(T service) where T : class
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            Debug.LogWarning($"Service {type} is already registered. Overwriting.");
        }
        _services[type] = service;
    }

    // Получение сервиса
    public T Get<T>() where T : class
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var service))
        {
            return service as T;
        }

        Debug.LogError($"Service of type {type} is not registered.");
        return null;
    }

    // Очистка (например, при перезапуске игры)
    public void Clear()
    {
        _services.Clear();
    }
}
