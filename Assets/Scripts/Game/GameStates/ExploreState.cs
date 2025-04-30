using UnityHFSM;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExploreState : BaseState
{
    public ExploreState(GameStateMachine game) : base(game) {}

    private SubtitlesService subtitles;
    private HideService showUI;
    private Coroutine currentCoroutine;

    public override void OnEnter()
    {
        showUI = Registry.Instance.Get<HideService>();
        subtitles = Registry.Instance.Get<SubtitlesService>();
        currentCoroutine = game.StartCoroutine(StateSequence());
    }

    private IEnumerator StateSequence()
    {
        subtitles.ShowSubtitleByKey("Explore_1");

        yield return new WaitForSeconds(15f);

        subtitles.ShowSubtitleByKey("Explore_2");

        yield return new WaitForSeconds(15f);

        subtitles.ShowSubtitleByKey("Explore_3");

        showUI.Subtitles(false);

        yield return new WaitForSeconds(15f);

        game.fsm.RequestStateChange("TillEvening");
    }

    public override void OnLogic()
    {
    }

    public override void OnExit()
    {
        if (currentCoroutine != null)
        {
            game.StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }
}
