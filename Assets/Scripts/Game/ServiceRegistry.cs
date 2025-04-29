using UnityEngine;

public class ServiceRegistry
{
    private CutsceneService _cutsceneService;

    public void SetCutsceneService(CutsceneService cutsceneService)
    {
        _cutsceneService = cutsceneService;
    }

    public CutsceneService GetCutsceneService()
    {
        return _cutsceneService;
    }
}
