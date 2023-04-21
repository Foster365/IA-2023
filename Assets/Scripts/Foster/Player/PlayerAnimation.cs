using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {

        public Animator _animator;

        public void RunningAnim(float velocity)
        {

            _animator.SetFloat("Vel", velocity);

        }

        public void JumpAnim()
        {
            _animator.SetTrigger("onJump");
        }

    }
}
