using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator _animator;

    // public void Grounded(bool _grounded)
    // {
    //     _animator.SetBool("Grounded", _grounded);
    // }

    public void RunningAnim(float velocity)
    {

        _animator.SetFloat("Vel", velocity);

    }

    //public void RunAnimation(bool _running)
    //{
    //    _animator.SetBool("Running", _running);
    //}

    public void JumpAnim()
    {
        _animator.SetTrigger("onJump");
    }
    

}
