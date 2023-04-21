using Player;
using System;
using UnityEngine;

namespace zzzNico.Entities.Player
{
    public class Player_View : MonoBehaviour
    {
        PlayerAnimation _playerAnimation;

        private void Awake()
        {
            _playerAnimation = GetComponent<PlayerAnimation>();
        }

        public void PlayRunAnimation(PlayerModel model)
        {
            _playerAnimation.RunningAnim(model.GetRigidbody().velocity.magnitude);
        }

        public void PlayerJumpAnimation()
        {
            _playerAnimation.JumpAnim();
        }

        public void ResetTriggerAnim(string _animName)
        {

            _playerAnimation._animator.ResetTrigger(_animName);
        }
    }
}