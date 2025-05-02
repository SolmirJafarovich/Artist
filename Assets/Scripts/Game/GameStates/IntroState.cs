using UnityHFSM;
using UnityEngine;

public class IntroState : BaseState
{
    // private bool isCutsceneStarted = false;

    public IntroState(GameStateMachine game) : base(game) {}

    // public string slidesFolder = "IntroSlides"; // Папка в Resources

    // public void InitUI()
    // {
    //     showUI.Dot(false);
    //     showUI.Cutscene(true);
    // }

    // public override void OnEnter()
    // {
    //     InitUI();
    //     cutsceneService.OnCutsceneFinished += HandleCutsceneFinish;
    //     cutsceneService.Init(slidesFolder);
    //     isCutsceneStarted = true;

    //     cutsceneService.NextSlide();
    // }

    // public override void OnLogic()
    // {
    //     // Проверка: нажата ли левая кнопка мыши
    //     if (isCutsceneStarted && Input.GetMouseButtonDown(0))
    //     {
    //         cutsceneService.NextSlide();
    //     }
    // }

    // private void HandleCutsceneFinish()
    // {
    //     game.fsm.RequestStateChange("Explore");
    // }

    // public override void OnExit()
    // {
    //     Debug.Log($"Exit state: {this.GetType().Name}");
    //     showUI.Cutscene(false);
    //     showUI.Dot(true);
    //     cutsceneService.OnCutsceneFinished -= HandleCutsceneFinish;
    // }
}
