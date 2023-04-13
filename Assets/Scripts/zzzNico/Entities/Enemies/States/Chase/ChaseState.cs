
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Chase
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "_main/States/EnemyStates/ChaseState", order = 0)]
    public class ChaseState : State
    {
        public override void ExecuteState(EntityModel model)
        {
            var target = ((EnemyModel)model).GetTarget();
            float dist= Vector3.Distance(model.transform.position, target.transform.position);
            var dir = (target.transform.position - model.transform.position).normalized;
            model.Move(dir);
        }
    }
}
