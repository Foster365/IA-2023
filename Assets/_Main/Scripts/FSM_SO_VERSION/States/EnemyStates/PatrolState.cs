using System.Collections.Generic;
using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "_main/States/EnemyStates/PatrolState", order = 0)]
    public class PatrolState : State
    {
        private Dictionary<EntityModel, DataMovementState> _movementDatas = new Dictionary<EntityModel, DataMovementState>();
        private class DataMovementState
        {
            public float Timer;
            public EnemyModel EnemyModel;
            public int PatrolCount;
            public bool TravelBackwards;

            public DataMovementState(EntityModel entityModel)
            {
                EnemyModel = (EnemyModel)entityModel;
                Assert.IsNotNull(EnemyModel);
                Timer = EnemyModel.GetData().RestPatrolTime;
                PatrolCount = 0;
                TravelBackwards = false;
            }
        }
        
        public override void EnterState(EntityModel model)
        {
            
            if (!_movementDatas.ContainsKey(model))
            {
                _movementDatas.Add(model, new DataMovementState(model));
            }

            model.isPatrolling = true;
        }

        public override void ExecuteState(EntityModel model)
        {
            var patrolPoints = _movementDatas[model].EnemyModel.GetPatrolPoints();
            
            var distToNextPoint = Vector3.Distance(patrolPoints[_movementDatas[model].PatrolCount].transform.position, model.transform.position);
            
            if (distToNextPoint > 1f)
            {
                var dirToNextPoint = (patrolPoints[_movementDatas[model].PatrolCount].transform.position - model.transform.position).normalized;
                
                model.Move(dirToNextPoint);
            }
            else
            {
                model.GetRigidbody().velocity = Vector3.zero;
                _movementDatas[model].Timer -= Time.deltaTime;
                if (_movementDatas[model].Timer <= 0 && !_movementDatas[model].TravelBackwards)
                {
                    _movementDatas[model].PatrolCount++;
                    
                    _movementDatas[model].Timer = _movementDatas[model].EnemyModel.GetData().RestPatrolTime;
                }
                else if (_movementDatas[model].Timer <= 0 && _movementDatas[model].TravelBackwards)
                {
                    
                    _movementDatas[model].PatrolCount--;
                    
                    _movementDatas[model].Timer = _movementDatas[model].EnemyModel.GetData().RestPatrolTime;
                }
            }

            if (_movementDatas[model].PatrolCount >= patrolPoints.Length -1)
            {
                _movementDatas[model].TravelBackwards = true;

            }
            else if (_movementDatas[model].PatrolCount <= 0)
            {
                _movementDatas[model].TravelBackwards = false;
            }
        }

        public override void ExitState(EntityModel model)
        {
            model.isPatrolling = false;
            model.Move(Vector3.zero);
        }
    }


}