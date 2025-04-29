using UnityHFSM;
using UnityEngine;

public class IntroState : BaseState
{
    private CutsceneService cutsceneService;
    private bool isCutsceneStarted = false;

    public IntroState(GameStateMachine game) : base(game) {}

    public string slidesFolder = "IntroSlides"; // Папка в Resources

    public override void OnEnter()
    {
        cutsceneService = Registry.Instance.GetCutsceneService();
        Debug.Log($"Registered: {cutsceneService}");

        cutsceneService.Init(slidesFolder);
        isCutsceneStarted = true;

        Debug.Log($"Enter state: {this.GetType().Name}");
    }

    public override void OnLogic()
    {
        // Проверка: нажата ли левая кнопка мыши
        if (isCutsceneStarted && Input.GetMouseButtonDown(0))
        {
            cutsceneService.NextSlide();
        }
    }

    public override void OnExit()
    {
        Debug.Log($"Exit state: {this.GetType().Name}");
    }
}
