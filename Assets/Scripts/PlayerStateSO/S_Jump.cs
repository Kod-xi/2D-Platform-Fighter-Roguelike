using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "S_Jump", menuName = "Project/FSM/State/S_Jump")]
public class S_Jump : State
{
    [SerializeField] private float jumpSpeed = 10f;

    public override void Enter(GameObject owner, StateContext stateContext)
    {
        Rigidbody2D rb = owner.GetComponent<Rigidbody2D>();

        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpSpeed);

    }

    public override void Tick(GameObject owner, StateContext stateContext)
    {}

    public override void Exit(GameObject owner, StateContext stateContext)
    {
        
    }
}