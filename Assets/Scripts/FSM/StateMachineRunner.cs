using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class StateMachineRunner : MonoBehaviour
{
    public StateMachine stateMachine;
    
    private StateContext stateContext;
    private State currentState;
    [SerializeField] private State[] attackStates;

    private void Awake()
    {
        stateContext = new StateContext();
    }

    private void Start()
    {
        currentState = stateMachine.initialState;
        
        currentState.Enter(gameObject, stateContext);
    }

    private void Update()
    {
        foreach(Transition transition in stateMachine.transitions)
        {
            if(!transition.fromStates.Contains(currentState)) continue;

            if (transition.ShouldTransition(gameObject, stateContext))
            {
                Debug.Log("Changing States");
                ChangeState(transition.toState);
                return;
            }
        }

        currentState?.Tick(gameObject, stateContext);
    } 

    private void ChangeState(State requestedState)
    {
        currentState.Exit(gameObject, stateContext);
        currentState = requestedState;
        currentState.Enter(gameObject, stateContext);
    }

    public void RequestAttack(Attack requestedAttack)
    {
        if(attackStates.Contains(currentState)) return;
        foreach(State attackState in attackStates)
        {
            if(attackState.attackType != requestedAttack) continue;
            stateContext.isAttacking = true;
            ChangeState(attackState);
            return;
        }
    }

    public void SetIsDashing(bool isDashing)
    {
        stateContext.isDashing = isDashing;
        Vector2 ownerPos = transform.position;
        stateContext.dashPoint = new Vector2(ownerPos.x + (3 * stateContext.PlayerInputDir), ownerPos.y);
        Debug.Log(stateContext.dashPoint.x - transform.position.x);
    }
    public void SetPlayerInputDir(float moveDir)
    {
        stateContext.PlayerInputDir = moveDir;
    }
}