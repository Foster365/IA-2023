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
            Debug.Log("Jump anim called");
            _animator.SetTrigger("onJump");
        }

    }
}
