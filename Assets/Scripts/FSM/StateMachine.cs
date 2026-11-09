using UnityEngine;

[CreateAssetMenu(fileName = "StateMachine", menuName = "Project/FSM/StateMachine")]
public class StateMachine : ScriptableObject
{
    public State initialState;
    public Transition[] transitions;
}
