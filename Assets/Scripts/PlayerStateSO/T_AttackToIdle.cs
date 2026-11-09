using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SocialPlatforms.GameCenter;

[CreateAssetMenu(fileName = "T_AttackToIdle", menuName = "Project/FSM/Transition/T_AttackToIdle")]
public class T_AttackToIdle : Transition
{
    public override bool ShouldTransition(GameObject owner, StateContext stateContext)
    { 
        if(!stateContext.isAttacking) return true;
        return false;
    }
}