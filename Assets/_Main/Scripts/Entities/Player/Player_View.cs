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

        public void PlayRunAnimation(PlayerModel model)
        {
            _animator.SetFloat("Vel", model.GetRigidbody().velocity.magnitude);
        }

        public void PlayerJumpAnimation()
        {
            _animator.SetTrigger("onJump");
        }

        public void ResetTriggerAnim(string _animName)
        {
            _animator.ResetTrigger(_animName);
        }
    }
}