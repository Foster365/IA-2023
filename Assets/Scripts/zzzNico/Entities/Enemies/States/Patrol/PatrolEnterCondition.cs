using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Patrol
{
    [CreateAssetMenu(fileName = "PatrolEnterCondition", menuName = "_main/Conditions/PatrolEnterCondition")]
    public class PatrolEnterCondition : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.isPatrolling;
        }
    }
}
