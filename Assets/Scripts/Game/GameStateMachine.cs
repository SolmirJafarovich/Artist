using UnityEngine;
using UnityHFSM;

public class GameStateMachine : MonoBehaviour
{
    public StateMachine fsm;

    [SerializeField] private CutsceneService cutsceneService;


    private void Awake()
    {
        fsm = new StateMachine();

        fsm.AddState("Intro", new IntroState(this));

        fsm.SetStartState("Intro");

        fsm.Init();
    }

    private void Update()
    {
        fsm.OnLogic();
    }

    public void TriggerEvent(string eventName)
    {
        Debug.Log($"Received event: {eventName}");
    }
}
