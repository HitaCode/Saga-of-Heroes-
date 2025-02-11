﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Dmgable))]

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;

    public float RunSpeed = 10f;

    public float airWalkSpeed = 3f;

    public float jumpImpulse = 10f;

    TouchingDirections touchingDirections;

    Mana playerMana;

    Dmgable dmgable;


    public float CurrentMoveSpeed { get
    {
            if (CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                    {
                        if (IsRunning)
                        {
                            return RunSpeed;
                        }
                        else
                        {
                            return walkSpeed;

                        }
                    }
                    else
                    {
                        return airWalkSpeed;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
    } }

    Vector2 moveInput;

    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get
        {
            return _isMoving;
        } 
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight { get { return _isFacingRight; } private set {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        } }
    
    public bool CanMove { get
        {
            return animator.GetBool(AnimationStrings.canMove);
        } 
    }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }




    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        dmgable = GetComponent<Dmgable>();
        playerMana = GetComponent<Mana>();
    }

    private void FixedUpdate()
    {
        if(!dmgable.LockVelocity)
            rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;
            SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        } 
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        } else if(context.canceled)
        {
            IsRunning = false;
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(playerMana.Maana < 100)
            {
                playerMana.Maana += 5;
                animator.SetTrigger(AnimationStrings.attack);
            }
            if(playerMana.Maana == 100)
            {
                animator.SetTrigger(AnimationStrings.attack);
            }
            
        }
    }
    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
    public void OnAttackSP(InputAction.CallbackContext context)
    {
        if (context.started && playerMana.Maana >= 50)
        {
            playerMana.Maana -= 50;
            animator.SetTrigger(AnimationStrings.attackSP);
        }
    }
    public void OnDefend(InputAction.CallbackContext context)
    {
        if (playerMana.Maana >= 0)
        {
            if(context.started && dmgable.IsDefend == false && playerMana.Maana >= 20)
            {
                playerMana.Maana -= 20;
                animator.SetTrigger(AnimationStrings.defend);
                dmgable.IsDefend = true;
            }
            if (context.canceled && dmgable.IsDefend == true && playerMana.Maana <= 100)
            {
                dmgable.IsDefend = false;
            }
        }
    }
}
