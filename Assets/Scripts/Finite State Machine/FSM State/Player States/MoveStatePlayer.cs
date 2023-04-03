using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStatePlayer<T> : FSMState<T>
{
    PlayerMC _player;
    Rigidbody _rigidbody;
    
    float _runSpeed;
    public MoveStatePlayer(PlayerMC player, Rigidbody rigidbody)
    {
        _player=player;
        _rigidbody=rigidbody;
    }

    public override void Awake()
    {
        // Debug.Log("MoveState Awake");
    }

    public override void Execute()
    {
        // Debug.Log("MoveState Execute");
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        _player.MovePlayer(dir);
    }

    public override void Sleep()
    {
        _rigidbody.velocity=Vector3.zero;
        // Debug.Log("MoveState Sleep");
    }
}
