using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Conditions
{
    [CreateAssetMenu(fileName = "DieConditions", menuName = "_main/Conditions/DieConditions")]
    public class DieConditions : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsDead();
        }
    }
}