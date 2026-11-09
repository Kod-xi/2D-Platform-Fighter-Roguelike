using UnityEngine;

public class StateContext
{
    public float attackTimer = 0f;
    public bool isAttacking = false;
    private int playerInputDir = 1;

    public float PlayerInputDir
    {
        get => playerInputDir;
        set
        {
            if(value > 0) 
            {
                playerInputDir = 1;
                return;
            }
            else if(value < 0)
            {
                playerInputDir = -1;
                return;
            }
        }
    }


    // public void UpdateAttackTimer(float clipLength)
    // {
    //     Debug.Log(clipLength >= attackTimer);
    //     if(clipLength >= attackTimer)
    //     {
    //         attackTimer = clipLength;
    //         return;
    //     }
    //     Debug.Log(clipLength + ", " + attackTimer );
    //     Debug.Log("Attacking is False");
    //     isAttacking = false;
    // }

    public void DecreaseAttackTimer()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            return;
        }
        isAttacking = false;

    }

    // Forward Attack State
    public Vector2 dashPoint = new();
    public bool isDashing = false;
    public float dashSpeed = 3f/13f;
}