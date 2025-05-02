using UnityHFSM;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TillEveningState : BaseState
{
    public TillEveningState(GameStateMachine game) : base(game) {}

    private SubtitlesService subtitles;
    private HideService showUI;
    private Coroutine currentCoroutine;


    private void InitUI()
    {
        showUI = Registry.Instance.Get<HideService>();
        showUI.Gameplay();
    }

    public override void OnEnter()
    {
        CameraCenterTrigger.OnCenterDotClick += HandleCenterClick;
        InitUI();
        subtitles = Registry.Instance.Get<SubtitlesService>();
        
    }

    public void HandleCenterClick(Collider collider)
    {
        GameObject clickedObject = collider.gameObject;
        if (clickedObject.name == "EntranceDoor")
        {
            Debug.Log("Это объект с именем EntranceDoor");
        }
    }

    public override void OnLogic()
    {
    }

    public override void OnExit()
    {
        CameraCenterTrigger.OnCenterDotClick -= HandleCenterClick;

        if (currentCoroutine != null)
        {
            game.StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }
}
