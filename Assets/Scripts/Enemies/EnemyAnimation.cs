using UnityEngine;

namespace Enemies
{
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
}
