
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Character _character;
    public CharacterController(Character p)
    {
        _character = p;
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_character.isGrounded)
                _character.Jump();
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        _character.Move(h, v);

        if (Input.GetKeyDown(KeyCode.G) && _character.CanAttack)
        {
            _character.Attack1();
        }

    }


}
