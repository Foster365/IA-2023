using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "JumpState", menuName = "_main/States/PlayerStates/JumpState", order = 0)]
    public class JumpStatePlayer : State
    {
        public override void EnterState(EntityModel model)
        {
            PlayerModel playerModel = model as PlayerModel;
            playerModel.Jump();
        }

        public override void ExecuteState(EntityModel model)
        {
            

        }
    }
}
