using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sounds;

public class Character : MonoBehaviour, ICollector, IHittable
{

    public float baseSpeed = 7f;
    public float baseJumpForce = 20f;
    public bool isGrounded;
    public bool canAttack;
    public Collider2D AttackRange;
    public bool invencibility = false;
    float canAttackTimer = 0f;
    public AudioClip[] ClipsAudio;

    CharacterController _control;
    Movement _movement;
    BattleMechanics _battleMechanics;
    SoundController _soundMananger;
    AnimatorController _animatorMananger;

    #region Properties
    public bool IsGrounded
    {
        get { return isGrounded; }
        set { isGrounded = value; }
    }

    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }
    #endregion

    private void Start()
    {
        _movement = new Movement(this);
        _battleMechanics = new BattleMechanics(this);
        _soundMananger = new SoundController(this);
        _animatorMananger = new AnimatorController(this);
        _control = new CharacterController(this);
    }

    private void Update()
    {
        _control.OnUpdate();

        if (canAttackTimer <= 0) { canAttack = true; AttackRange.enabled = false; }
        canAttackTimer -= Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") { IsGrounded = true; }

    }
    #region Movement
    internal void Jump()
    {
        _soundMananger.SoundPlay((int)sounds.JUMP);
        _animatorMananger.Jump();

        StartCoroutine(_movement.Jump());
    }

    internal void Move(float h, float v)
    {
        if (h != 0 || v != 0)
        {
            _animatorMananger.Move(h);
            _movement.Move(h, v);
        }
        else { _animatorMananger.Move(0); _movement.Move(0, 0);
        }
    }

    public void ChangeMovementSpeed(float speed)
    {
        _movement.SetSpeed = speed;
    }

    public void ChangeJumpForce(float jumpForce)
    {
        _movement.SetJumpForce = jumpForce;
    }

    #endregion

    #region Battle
    internal void Attack1()
    {
        _battleMechanics.Attack1();
        _animatorMananger.Attack1();
        _soundMananger.SoundPlay((int)sounds.ATTACK);
    } 
    internal void Attack2()
    {
        _battleMechanics.Attack2();
        _animatorMananger.Attack2();
        _soundMananger.SoundPlay((int)sounds.ATTACK);
    }

    public void ResetTimerAttack()
    {
        canAttackTimer = 0.6f;
    }

    public void GetHit(float damage)
    {
        _soundMananger.SoundPlay((int)2);

        if (invencibility) return;

        _animatorMananger.Die();
        this.enabled = false;
    
        StartCoroutine(Invencibility(1f));
        _animatorMananger.GetHit();
    }

    public IEnumerator Invencibility(float seconds)
    {
        invencibility = true;
        yield return new WaitForSeconds(seconds);
        invencibility = false;
        yield return null;
    }

    #endregion





}
