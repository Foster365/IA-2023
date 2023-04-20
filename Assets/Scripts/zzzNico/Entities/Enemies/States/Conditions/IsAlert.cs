using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Conditions
{
    [CreateAssetMenu(fileName = "IsAlert", menuName = "_main/Conditions/EnemyConditions/IsAlert")]
    public class IsAlert : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.isAllert;
        }
    }
}
