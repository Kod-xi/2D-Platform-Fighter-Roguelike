using UnityEngine;
using UnityEngine.Analytics;

[CreateAssetMenu(fileName = "S_Forward", menuName = "Project/FSM/State/S_Forward")]
public class S_Forward : State
{
    [SerializeField] private AnimationClip forwardClip;
    public override Attack attackType => Attack.Forward;
    public override void Enter(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Entering Forward State");
        PlayerAnimator anim = owner.GetComponent<PlayerAnimator>();
        anim.PlayerForwardAnimation();
        stateContext.attackTimer = forwardClip.length;
    }

    public override void Exit(GameObject owner, StateContext stateContext)
    {
        Debug.Log("Exiting Forward State");
        stateContext.attackTimer = 0;

    }

    public override void Tick(GameObject owner, StateContext stateContext)
    { 
       stateContext.DecreaseAttackTimer();
       AttemptDash(owner, stateContext);
    }

    private void AttemptDash(GameObject owner, StateContext stateContext)
    {
        if (!stateContext.isDashing) return;
        owner.transform.position = Vector2.MoveTowards(owner.transform.position, stateContext.dashPoint, stateContext.dashSpeed);
    }
}