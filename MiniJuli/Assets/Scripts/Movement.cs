using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    Character _character;
    Rigidbody2D _rb;
    float _jumpForce = 15f;
    float _speed = 7f;
    private Vector3 velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float turnSmoothVelocity = .05f;
    private bool facingRight = true; 


    public float speedForward = 6f;
    public float speedRight = 6f;
    public float rotSpeed = 6f;

    public Movement(Character character)
    {
        this._character = character;
        SetSpeed = _character.baseSpeed;
        _rb = _character.GetComponent<Rigidbody2D>();


    }
    #region PROPERTIES
    public float SetSpeed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }
    public float SetJumpForce
    {
        get
        {
            return _jumpForce;
        }
        set
        {
            _jumpForce = value;
        }
    }

    #endregion


    public IEnumerator Jump()
    {
        if (!_character.IsGrounded) yield return null;
        _character.IsGrounded = false;
        float jumpForce = _jumpForce;
        Vector2 force = new Vector2(0, jumpForce);
        yield return new WaitForSeconds(0.1f);
        _rb.AddForce(force, ForceMode2D.Impulse);

        yield return null;
    }

    public void Move(float h, float vh)
    {

        _rb.velocity = new Vector3(h * _speed, _rb.velocity.y, 0);


        Vector3 direction = new Vector3(h, 0, 0).normalized;

        //if (_rb.velocity.y < -limitFallSpeed)
        //    _rb.velocity = new Vector2(_rb.velocity.x, -limitFallSpeed);

        Vector3 targetVelocity = new Vector2(h * 10f, _rb.velocity.y);

        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref velocity, turnSmoothVelocity);

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = _character.transform.localScale;
        theScale.x *= -1;
        _character.transform.localScale = theScale;
    }
}
