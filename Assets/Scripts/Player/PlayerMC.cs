using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMC : MonoBehaviour
{

    public float runSpeed, jumpForce;
    bool _grounded = false;
    public float life=100;
    
    Rigidbody _rigidbody;
    Transform _transform;
    PlayerAnimation _playerAnimation;

    void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimation = GetComponent<PlayerAnimation>();

    }
    
    public void CheckJump()
    {
        _rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
    }

    public void MovePlayer(Vector3 dir)
    {
        dir.y = 0;
        _rigidbody.velocity = dir * runSpeed;
        if(dir!=Vector3.zero)
        {
            transform.forward = dir;
            _playerAnimation.RunningAnim(_rigidbody.velocity.magnitude);
        }
    }
    
    public void CheckGround()
    {

        _grounded = Physics.Raycast(transform.position, -transform.up, 1f, 1 << LayerMask.NameToLayer("Ground")) ? true : false;

    }

    public void Healer(int heal)
    {
        life=+heal;
    }

    public void GetDamage(int damage)
    {
        life=-damage;
        Debug.Log("You lose! Closing...");
        Application.Quit();
    }
}
