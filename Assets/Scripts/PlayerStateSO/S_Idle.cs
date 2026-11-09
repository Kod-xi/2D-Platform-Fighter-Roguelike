using UnityEngine;

[CreateAssetMenu(fileName = "S_Idle", menuName = "Project/FSM/State/S_Idle")]
public class S_Idle : State
{
    public override void Enter(GameObject owner, StateContext stateContext)
    {
        
    }

    public override void Tick(GameObject owner, StateContext stateContext)
    {}

    public override void Exit(GameObject owner, StateContext stateContext)
    {
        // Debug.Log("Exiting Idle State");
    }
}