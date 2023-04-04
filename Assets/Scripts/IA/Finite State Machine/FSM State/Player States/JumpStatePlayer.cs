using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStatePlayer<T> : FSMState<T>
{
    FSM<T> _fsm;
    T _idleState;

    Character _player;

    public JumpStatePlayer(FSM<T> fsm, T idleState, Character player)
    {
        _fsm = fsm;
        _idleState = idleState;
        _player = player;
    }
    public override void Awake()
    {
        _player.Jump();
    }
    public override void Execute()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h == 0 || v == 0) _fsm.Transition(_idleState);
    }
}
