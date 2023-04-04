using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStatePlayer<T> : FSMState<T>
{

    FSM<T> _fsm;
    T _idleState;
    T _jumpState;

    Character _player;
    Rigidbody _rigidbody;

    float _runSpeed;
    public MoveStatePlayer(FSM<T> fsm, T idleState, T jumpState, Character player, Rigidbody rigidbody)
    {

        _fsm = fsm;
        _idleState = idleState;
        _jumpState = jumpState;

        _player = player;
        _rigidbody = rigidbody;
    }

    public override void Execute()
    {
        Debug.Log("MoveState Execute");

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        _player.Move(dir);

        if (h == 0 || v == 0) _fsm.Transition(_idleState);
        else if (Input.GetKeyDown(KeyCode.Space)) _fsm.Transition(_jumpState);

    }

    public override void Sleep()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
