using System;
using UnityEngine;

[CreateAssetMenu(fileName = "S_Jab", menuName = "Project/FSM/State/S_Jab")]
public class S_Jab : State
{
    [SerializeField] private AnimationClip jabClip;
    public override Attack attackType => Attack.Jab;

    public override void Enter(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Entering Jab State");
        PlayerAnimator anim = owner.GetComponent<PlayerAnimator>();
        anim.PlayerJabAnimation();
        stateContext.attackTimer = jabClip.length;
    }

    public override void Exit(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Exiting Jab State");
        stateContext.attackTimer = 0;
    }

    public override void Tick(GameObject owner, StateContext stateContext)
    {
        stateContext.DecreaseAttackTimer();
    }
}