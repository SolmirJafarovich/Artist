using UnityHFSM;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TillEveningState : BaseState
{
    public TillEveningState(GameStateMachine game) : base(game) {}

    private SubtitlesService subtitles;
    private HideService showUI;
    private DoorbellService doorbell;
    private Coroutine currentCoroutine;

    private void InitUI()
    {
        showUI = Registry.Instance.Get<HideService>();
        showUI.Gameplay();
    }

    public override void OnEnter()
    {
        InitUI();
        showUI = Registry.Instance.Get<HideService>();
        subtitles = Registry.Instance.Get<SubtitlesService>();
        doorbell = Registry.Instance.Get<DoorbellService>();
        currentCoroutine = game.StartCoroutine(StateSequence());
    }

    private IEnumerator StateSequence()
    {
        doorbell.Ring();
        yield return new WaitForSeconds(15f);
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
