using UnityHFSM;
using UnityEngine;

public abstract class BaseState : State
{
    protected GameStateMachine game;

    public BaseState(GameStateMachine game)
    {
        this.game = game;
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
