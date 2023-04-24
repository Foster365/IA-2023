using UnityEngine;

namespace _Main.Scripts.Entities.Player
{
    public class Player_View : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayRunAnimation(bool _isMoving)
        {
            _animator.SetBool("isMoving", _isMoving);
            //_animator.SetFloat("Vel", model.GetRigidbody().velocity.magnitude);
        }

        public void PlayerJumpAnimation(bool _isJumping)
        {
            _animator.SetBool("isJumping", _isJumping);
            //_animator.SetTrigger("onJump");
        }

        public void PlayerGroundedAnimation(bool _isGrounded)
        {
            _animator.SetBool("isGrounded", _isGrounded);
            //_animator.SetTrigger("onJump");
        }

        public void PlayerFallingAnimation(bool _isFalling)
        {
            _animator.SetBool("isFalling", _isFalling);
            //_animator.SetTrigger("onJump");
        }

        public void ResetTriggerAnim(string _animName)
        {
            _animator.ResetTrigger(_animName);
        }
    }
}