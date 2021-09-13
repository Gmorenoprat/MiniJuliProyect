using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Character _character;
    Animator _anim;

    public AnimatorController(Character character)
    {
        this._character = character;
        _anim = _character.GetComponent<Animator>();

    }

    public void Attack1()
    {
        _anim.Play("ATTACK1");
    }
    public void Attack2()
    {
        _anim.Play("Attack2");
    }

    public void Die()
    {
        _anim.SetBool("isDead", true);
    }

    public void GetHit()
    {
        _anim.SetTrigger("getHit");
    }

    public void Move(float spd)
    {
        _anim.SetFloat("Speed", Mathf.Abs(spd));
    }
    public void Jump()
    {
        _anim.Play("JUMP");
    }

}
