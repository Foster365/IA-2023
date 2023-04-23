using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "WalkState", menuName = "_main/States/PlayerStates/WalkState", order = 0)]

    public class WalkStatePlayer : State
    {
        public override void ExecuteState(EntityModel model)
        {
            var horizontalInput = model.transform.right * Input.GetAxis("Horizontal");
            var verticalInput = model.transform.forward * Input.GetAxis("Vertical");

            
            Vector3 dir = (horizontalInput + verticalInput).normalized;
            
            
            if (dir.magnitude != 0)
            {
                model.Move(dir);
                model.LookDir(model.GetFoward());
            }
            
        }
        public override void ExitState(EntityModel model)
        {
            model.Move(Vector3.zero);
        }

    }
}
