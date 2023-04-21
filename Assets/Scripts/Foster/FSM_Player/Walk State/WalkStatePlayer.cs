using UnityEngine;
using zzzNico.Entities;
using zzzNico.FSM_SO_VERSION;

namespace Foster.FSM_Player.Walk_State
{
    [CreateAssetMenu(fileName = "WalkState", menuName = "_main/States/PlayerStates/WalkState", order = 0)]

    public class WalkStatePlayer : State
    {
        public override void ExecuteState(EntityModel model)
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");

            Vector3 dir = new Vector3(horizontalInput, 0, verticalInput);

            if (horizontalInput != 0 || verticalInput != 0)
            {
                model.Move(dir);
                model.LookDir(model.GetFoward);
            }
        }
        public override void ExitState(EntityModel model)
        {
            model.Move(Vector3.zero);
        }

    }
}
