using UnityHFSM;
using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class IntroState : BaseState
{
    private CutsceneService cutsceneService;

    [Inject]
    private void Contstruct(CutsceneService _cutsceneService)
    {
        cutsceneService = _cutsceneService;
        Debug.Log($"Success! Injection: {_cutsceneService}");
    }

    public IntroState(GameStateMachine game) : base(game) {}
    public string slidesFolder = "IntroSlides"; // Папка в Resources

    private void StartCutscene()
    {
        this.cutsceneService.StartCutscene(slidesFolder);
    }

    public override void OnEnter()
    {
        StartCutscene();
        Debug.Log($"Enter state: {this.GetType().Name}");
    }

    public override void OnExit()
    {
        Debug.Log($"Exit state: {this.GetType().Name}");
    }
}
