
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Chase
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "_main/States/EnemyStates/ChaseState", order = 0)]
    public class ChaseState : State
    {
        EnemyRouletteWheel roulette;
        EnemyModel enemyModel;
        public override void EnterState(EntityModel model)
        {
            enemyModel = model as EnemyModel;
            roulette = enemyModel.Controller.EnemyRoulette;
            roulette.SbRouletteInitNode.Execute();

        }
        public override void ExecuteState(EntityModel model)
        {
            Vector3 dir = enemyModel.Controller.EnemySbController.SbRouletteDir;

            if (dir != Vector3.zero) model.Move(dir);
        }
    }
}
