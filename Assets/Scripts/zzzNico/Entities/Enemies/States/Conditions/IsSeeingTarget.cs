using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Conditions
{
    [CreateAssetMenu(fileName = "IsSeeingTarget", menuName = "_main/Conditions/EnemyConditions/IsSeeingTarget")]
    public class IsSeeingTarget : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
        
            var thisModel = (EnemyModel)model;
            return thisModel.LineOfSight(thisModel.GetTarget().transform);
        }
    }
}
