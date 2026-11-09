using UnityEngine;

public abstract class Transition : ScriptableObject
{
    public State[] fromStates;
    public State toState;

    public abstract bool ShouldTransition(GameObject owner, StateContext context);
}