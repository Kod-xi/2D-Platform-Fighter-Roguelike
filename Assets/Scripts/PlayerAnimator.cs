using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private StateMachineRunner stateMachine;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachineRunner>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void PlayerJabAnimation()
    {
        animator.SetTrigger("Jab");
    }

    public void PlayerForwardAnimation()
    {
        animator.SetTrigger("Forward");
    }

    public void PlayerDownAnimation()
    {
        animator.SetTrigger("Down");
    }

    public void PlayerUpAnimation()
    {
        animator.SetTrigger("Up");
    }

    public AnimatorStateInfo GetStateInfo()
    {
        return animator.GetCurrentAnimatorStateInfo(0);
    }

    public void OnForwardDashEnter()
    {
        stateMachine.SetIsDashing(true);
    }

    public void OnForwardDashExit()
    {
        stateMachine.SetIsDashing(false);
    }
}
