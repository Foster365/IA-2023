using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using zzzNico.Entities.Player;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.Patrol
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "_main/States/EnemyStates/PatrolState", order = 0)]
    public class PatrolState : State
    {
        private Dictionary<EntityModel, DataMovementState> _movementDatas = new Dictionary<EntityModel, DataMovementState>();
        private DataMovementState _enemyModelData;
        private struct DataMovementState
        {
            public float timer;
            public EnemyModel enemyModel;
            public int patrolCount;

            public DataMovementState(EntityModel entityModel)
            {
                enemyModel = (EnemyModel)entityModel;
                Assert.IsNotNull(enemyModel);
                timer = enemyModel.GetPatrolTimer();
                patrolCount = 0;
            }
        }
        
        public override void EnterState(EntityModel model)
        {
            
            if (!_movementDatas.ContainsKey(model))
            {
                _movementDatas.Add(model, new DataMovementState(model));
                _enemyModelData = _movementDatas[model];
            }
        }

        public override void ExecuteState(EntityModel model)
        {
            var patrolPoints = _enemyModelData.enemyModel.GetPatrolPoints();
            
            var distToNextPoint = Vector3.Distance(patrolPoints[_enemyModelData.patrolCount].transform.position, model.transform.position);

            if (distToNextPoint > 0.5f)
            {
                var dirToNextPoint = (patrolPoints[_enemyModelData.patrolCount].transform.position - model.transform.position).normalized;
                
                model.Move(dirToNextPoint);
            }
            else
            {
                _enemyModelData.timer -= Time.deltaTime;
                if (_enemyModelData.timer <= 0)
                {
                    _enemyModelData.patrolCount++;
                    
                    _enemyModelData.timer = _enemyModelData.enemyModel.GetPatrolTimer();
                }
            }
            
            if (_enemyModelData.patrolCount >= patrolPoints.Length)
                _enemyModelData.patrolCount = 0;
        }

        public override void ExitState(EntityModel model)
        {
            _enemyModelData.enemyModel.isPatrolling = false;
        }
    }


}