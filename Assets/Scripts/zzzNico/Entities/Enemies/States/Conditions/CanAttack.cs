using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Conditions
{
    [CreateAssetMenu(fileName = "CanAttack", menuName = "_main/Conditions/EnemyConditions/CanAttack")]
    public class CanAttack : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            var enemyModel = (EnemyModel)model;
            var distanceToTarget =
                Vector3.Distance(enemyModel.GetTarget().transform.position, model.transform.position);
            return distanceToTarget < enemyModel.GetData().DistanceToAttack;
        }
    }
}