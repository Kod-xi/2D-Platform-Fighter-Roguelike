using UnityEngine;

public abstract class State : ScriptableObject
{
    public virtual Attack attackType => Attack.Passive;
    public abstract void Enter(GameObject owner, StateContext stateContext);
    public abstract void Tick(GameObject owner, StateContext stateContext);
    public abstract void Exit(GameObject owner, StateContext stateContext);
}