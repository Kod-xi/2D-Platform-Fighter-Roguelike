using UnityEngine;

[CreateAssetMenu(fileName = "T_JumpToIdle", menuName = "Project/FSM/Transition/T_JumpToIdle")]
public class T_JumpToIdle : Transition
{
    public override bool ShouldTransition(GameObject owner, StateContext stateContext)
    { 
        if(stateContext.State == ActionableStates.Grounded) return true;
        return false;
    }
}