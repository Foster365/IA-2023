using System.Collections.Generic;
using Foster.EnemyRouletteWheel;
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.States
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "_main/States/EnemyStates/ChaseState", order = 0)]
    public class ChaseState : State
    {
        private Dictionary<EntityModel, EnemyModel> _entitiesData = new Dictionary<EntityModel, EnemyModel>();

        EnemyRouletteWheel _roulette;
        EnemyModel _enemyModel;
        public override void EnterState(EntityModel model)
        {
            _enemyModel = model as EnemyModel;
            if (!_entitiesData.ContainsKey(model)) _entitiesData.Add(model, _enemyModel);

            _roulette = _enemyModel.Controller.EnemyRoulette;
            _roulette.RouletteAction();
            _entitiesData[model].isChasing = true;
        }
        public override void ExecuteState(EntityModel model)
        {
            Vector3 dir = _entitiesData[model].Controller.EnemySbController.SbRouletteDir;

            if (dir != Vector3.zero)
            {
                Debug.Log("Chasing player");
                _entitiesData[model].Move(dir);
            }
        }


        public override void ExitState(EntityModel model)
        {
            if (_entitiesData.ContainsKey(model)) _entitiesData.Remove(model);
            model.isChasing = false;
        }
    }
}
