using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMechanics : MonoBehaviour
{
    private Character _character;

    public BattleMechanics(Character character)
    {
        this._character = character;
    }

    public void Attack1()
    {
        if (!_character.CanAttack) return;
        _character.CanAttack = false;
        _character.ResetTimerAttack();
        _character.AttackRange.enabled = true;

    }    
    public void Attack2()
    {
        if (!_character.CanAttack) return;
        _character.CanAttack = false;
        _character.ResetTimerAttack();
        _character.AttackRange.enabled = true;

    }

}

