using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStatePlayer<T> : FSMState<T>
{

    Rigidbody _rigidbody;
    public IdleStatePlayer(Rigidbody rigidbody)
    {
        _rigidbody=rigidbody;
    }

    public override void Execute()
    {
        //Reproducir animación idle.
    }
}
