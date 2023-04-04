using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class IdleStatePlayer<T> : FSMState<T>
{

    FSM<T> _fsm;
    T _moveState, _jumpState;

    Character _player;

    public IdleStatePlayer(FSM<T> fsm, T moveState, T jumpState, Character player)
    {
        _fsm = fsm;
        _moveState = moveState;
        _jumpState = jumpState;
        _player = player;
    }

    public override void Execute()
    {
        Debug.Log("IdleState Execute");

        _player.CheckGround();

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0) _fsm.Transition(_moveState);
        else if (Input.GetKeyDown(KeyCode.Space)) _fsm.Transition(_jumpState);

        //Reproducir animación idle.
    }
}
