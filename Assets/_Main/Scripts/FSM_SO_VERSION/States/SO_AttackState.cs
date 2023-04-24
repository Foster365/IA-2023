using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States
{
    public class SO_AttackState : State
    {

        public override void EnterState(EntityModel model)
        {
            
        }

        public override void ExecuteState(EntityModel model)
        {
            var enemyModel = (EnemyModel)model;
            var dirToTarget = (enemyModel.GetTarget().transform.position - model.transform.position);
            
            if (Physics.Raycast(model.transform.position + Vector3.up,dirToTarget, enemyModel.GetData().DistanceToAttack, enemyModel.GetData().TargetLayer))
            {
                model.DoDamage(enemyModel.GetTarget());
            }
        }
    }
}