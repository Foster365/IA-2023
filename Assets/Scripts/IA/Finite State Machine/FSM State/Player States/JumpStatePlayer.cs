using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStatePlayer<T> : FSMState<T>
{
    Character _player;

    public JumpStatePlayer(Character player, Rigidbody rigidbody)
    {
        _player=player;
    }

    public override void Execute()
    {
        _player.Jump();
    }
}
