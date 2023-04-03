using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStatePlayer<T> : FSMState<T>
{
    Rigidbody _rigidbody;
    PlayerMC _player;
    PlayerAnimation _playerAnimation;

    public JumpStatePlayer(PlayerMC player, PlayerAnimation playerAnimation, Rigidbody rigidbody)
    {
        _player=player;
        _playerAnimation=playerAnimation;
        _rigidbody=rigidbody;
    }

    public override void Awake()
    {
         // Debug.Log("JumpState Awake");
        _player.CheckJump();
        _playerAnimation.JumpAnim();
    }

    public override void Execute()
    {
    }

    public override void Sleep()
    {
        // Debug.Log("JumpState Sleep");
    }
}
