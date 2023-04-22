using UnityEngine;

namespace Enemies
{
    public class EnemyAnimation : MonoBehaviour
    {

        public Animator _animator;

        public void RunningAnim(float velocity)
        {
            _animator.SetFloat("Vel", velocity);

        }

    }
}
