using System;
using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private StateMachineRunner stateMachine;
    private Rigidbody2D playerRb;
    private float moveDir;
    private float vertInput;
    private bool isMovementEnabled = true;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    private float currentSpeed;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachineRunner>();
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        currentSpeed = 0;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        
    }

    public void OnMove(InputValue input)
    {
        moveDir = input.Get<Vector2>().x;
        vertInput = input.Get<Vector2>().y;
        stateMachine.SetPlayerInputDir(moveDir);
    }

    private void Move()
    {
        if(!isMovementEnabled) return;
        float maxVelocity = moveDir * maxSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxVelocity, acceleration * Time.deltaTime);
        playerRb.linearVelocity = new Vector2(currentSpeed, playerRb.linearVelocity.y);
        CharacterLookDirection();
    }

    public void OnAttack(InputValue input)
    {
        if(!input.isPressed) return;
        if(vertInput > .1) 
        {
            stateMachine.RequestAttack(Attack.Up);
            return;
        }
        else if(vertInput < -.1) 
        {
            stateMachine.RequestAttack(Attack.Down);
            return;
        }
        if(Math.Abs(moveDir) > .1) 
        {
            stateMachine.RequestAttack(Attack.Forward);
            return;
        }
        stateMachine.RequestAttack(Attack.Jab);
    }

    private void CharacterLookDirection()
    {
        if(moveDir == 0) return;
        if(moveDir > 0) 
        {
            transform.localScale = Vector3.one;
            return;
        }
        transform.localScale = new Vector3( -1, 1, 1);
    }

    public void EnableMovement()
    {
        isMovementEnabled = true;
    }

    public void DisableMovement()
    {
        isMovementEnabled = false;
    }
}

public enum Attack {Passive, Jab, Forward, Up, Down}

