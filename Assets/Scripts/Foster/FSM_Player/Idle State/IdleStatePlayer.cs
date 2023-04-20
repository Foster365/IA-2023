using UnityEngine;
using zzzNico.Entities;
using zzzNico.FSM_SO_VERSION;

namespace Foster.FSM_Player.Idle_State
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "_main/States/PlayerStates/IdleState", order = 0)]
    public class IdleStatePlayer : State
    {
        public override void EnterState(EntityModel model)
        {
            model._Rb.velocity = Vector3.zero;
        }
        public override void ExecuteState(EntityModel model)
        {
            model._Rb.velocity = Vector3.zero;
        }
    }
}
