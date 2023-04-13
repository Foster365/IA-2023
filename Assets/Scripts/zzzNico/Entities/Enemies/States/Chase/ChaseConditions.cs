using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Chase
{
    [CreateAssetMenu(fileName = "ChaseConditions", menuName = "_main/Conditions/ChaseConditions")]
    public class ChaseConditions : StateCondition
    {
    
        public override bool CompleteCondition(EntityModel model)
        {
            return model.isChasing;
        }
    }
}
