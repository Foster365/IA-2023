using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    
    public Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAnimation()
    {
        _animator.SetTrigger("Running");
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("Attacking");
    }

}
