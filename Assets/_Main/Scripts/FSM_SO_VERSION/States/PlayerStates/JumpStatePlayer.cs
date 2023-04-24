using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using System;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "JumpState", menuName = "_main/States/PlayerStates/JumpState", order = 0)]
    public class JumpStatePlayer : State
    {
        PlayerModel playerModel;
        public override void EnterState(EntityModel model)
        {
            playerModel = model as PlayerModel;
            playerModel.View.PlayerJumpAnimation(true);
        }

        public override void ExecuteState(EntityModel model)
        {
            playerModel.GetRigidbody().velocity = Vector3.zero;
            playerModel.Jump();

        }
        public override void ExitState(EntityModel model)
        {
            playerModel.View.PlayerJumpAnimation(false);
        }
    }
}
