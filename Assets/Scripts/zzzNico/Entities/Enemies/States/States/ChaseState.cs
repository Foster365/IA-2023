using Foster.EnemyRouletteWheel;
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.States
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "_main/States/EnemyStates/ChaseState", order = 0)]
    public class ChaseState : State
    {
        EnemyRouletteWheel _roulette;
        EnemyModel _enemyModel;
        public override void EnterState(EntityModel model)
        {
            _enemyModel = model as EnemyModel;
            _roulette = _enemyModel.Controller.EnemyRoulette;
            _roulette.SbRouletteInitNode.Execute();


            model.isChasing = true;
        }
        public override void ExecuteState(EntityModel model)
        {
            Vector3 dir = _enemyModel.Controller.EnemySbController.SbRouletteDir;

            if (dir != Vector3.zero) model.Move(dir);
        }


        public override void ExitState(EntityModel model)
        {
            
            model.isChasing = false;
        }
    }
}
