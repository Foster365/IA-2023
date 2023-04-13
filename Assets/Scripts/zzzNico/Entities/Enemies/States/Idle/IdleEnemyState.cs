using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Idle
{
    [CreateAssetMenu(fileName = "IdleEnemyState", menuName = "_main/States/EnemyStates/IdleState", order = 0)]
    public class IdleEnemyState : State
    {
        public override void EnterState(EntityModel model)
        {
        }

        public override void ExecuteState(EntityModel model)
        {
        }

        public override void ExitState(EntityModel model)
        {
            model.isIdle = false;
        }
    }
} 