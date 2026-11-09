using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "S_Down", menuName = "Project/FSM/State/S_Down")]
public class S_Down : State
{
    [SerializeField] private AnimationClip downClip;
    public override Attack attackType => Attack.Down;
    public override void Enter(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Entering Down State");
        PlayerAnimator anim = owner.GetComponent<PlayerAnimator>();
        anim.PlayerDownAnimation();
        stateContext.attackTimer = downClip.length;
    }

    public override void Exit(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Exiting Down State");
        stateContext.attackTimer = 0;
    }

    public override void Tick(GameObject owner, StateContext stateContext)
    {
        stateContext.DecreaseAttackTimer();
    }
}