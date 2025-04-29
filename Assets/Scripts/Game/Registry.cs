using UnityEngine;
using System;

public class Registry
{
    private static Registry _instance;
    private static readonly object _lock = new object();

    private CutsceneService _cutsceneService;

    // Приватный конструктор для предотвращения создания экземпляров
    private Registry() {}

    // Свойство для доступа к экземпляру
    public static Registry Instance
    {
        get
        {
            // Используем блокировку для безопасности в многозадачности
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Registry();
                }
                return _instance;
            }
        }
    }
    public void SetCutsceneService(CutsceneService cutsceneService)
    {
        _cutsceneService = cutsceneService;
    }

    public CutsceneService GetCutsceneService()
    {
        return _cutsceneService;
    }
}
