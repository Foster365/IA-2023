using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.States
{
    [CreateAssetMenu(fileName = "AttackState", menuName = "_main/States/EnemyStates/AttackState", order = 0)]
    public class AttackState : State
    {
        private EnemyModel _enemyModel;
        public override void EnterState(EntityModel model)
        {
            model.isAttacking = true;
            _enemyModel = (EnemyModel)model;
        }

        public override void ExecuteState(EntityModel model)
        {
            _enemyModel.Attack(Vector3.up);
        }

        public override void ExitState(EntityModel model)
        {
            model.isAttacking = false;
        }
    }
}