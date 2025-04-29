using UnityHFSM;
using UnityEngine;
using System.Collections.Generic;

public class IntroState : BaseState
{
    public IntroState(GameStateMachine game) : base(game) {}
    public string slidesFolder = "IntroSlides"; // Папка в Resources

    private void StartCutscene()
    {
        this.game.cutsceneService.StartCutscene(slidesFolder);
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
