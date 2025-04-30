using UnityEngine;
using UnityHFSM;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private string startState = "Intro";

    public StateMachine fsm;

    private void Start()
    {
        fsm = new StateMachine();

        fsm.AddState("Intro", new IntroState(this));
        fsm.AddState("Explore", new ExploreState(this));
        fsm.AddState("TillEvening", new TillEveningState(this));

        fsm.SetStartState(startState);

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
