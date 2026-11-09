using UnityEngine;

[CreateAssetMenu(fileName = "S_Up", menuName = "Project/FSM/State/S_Up")]
public class S_Up : State
{
    public override Attack attackType => Attack.Up;
    [SerializeField] private AnimationClip upClip;
    public override void Enter(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Entering Up State");
        PlayerAnimator anim = owner.GetComponent<PlayerAnimator>();
        anim.PlayerUpAnimation();
        stateContext.attackTimer = upClip.length;
    }

    public override void Exit(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Exiting Up State");
        stateContext.attackTimer = 0;
    }

    public override void Tick(GameObject owner, StateContext stateContext)
    {
        stateContext.DecreaseAttackTimer();
    }
}