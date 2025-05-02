using UnityHFSM;
using UnityEngine;

public abstract class BaseState : State
{
    protected GameStateMachine game;

    protected SubtitlesService subtitles;
    protected HideService showUI;
    protected DoorbellService doorbell;
    protected CutsceneService cutsceneService;

    public BaseState(GameStateMachine game)
    {
        this.game = game;
        showUI = Registry.Instance.Get<HideService>();
        subtitles = Registry.Instance.Get<SubtitlesService>();
        doorbell = Registry.Instance.Get<DoorbellService>();
        cutsceneService = Registry.Instance.Get<CutsceneService>();
    }

    public override void OnEnter()
    {
        Debug.Log($"Enter state: {this.GetType().Name}");
    }

    public override void OnExit()
    {
        Debug.Log($"Exit state: {this.GetType().Name}");
    }
}
