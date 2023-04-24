﻿using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections.Generic;
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
            public float timer;
            public EnemyModel enemyModel;
            public int patrolCount;

            public DataMovementState(EntityModel entityModel)
            {
                enemyModel = (EnemyModel)entityModel;
                Assert.IsNotNull(enemyModel);
                timer = enemyModel.GetData().RestPatrolTime;
                patrolCount = 0;
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
            var patrolPoints = _movementDatas[model].enemyModel.GetPatrolPoints();

            var distToNextPoint = Vector3.Distance(patrolPoints[_movementDatas[model].patrolCount].transform.position, model.transform.position);

            if (distToNextPoint > 1f)
            {
                var dirToNextPoint = (patrolPoints[_movementDatas[model].patrolCount].transform.position - model.transform.position).normalized;

                model.Move(dirToNextPoint);
            }
            else if (_movementDatas[model].enemyModel.transform.position == patrolPoints[_movementDatas[model].patrolCount].transform.position)
                Debug.Log("BUENAS");
            else
            {
                model.GetRigidbody().velocity = Vector3.zero;
                _movementDatas[model].timer -= Time.deltaTime;
                if (_movementDatas[model].timer <= 0)
                {
                    _movementDatas[model].patrolCount++;

                    _movementDatas[model].timer = _movementDatas[model].enemyModel.GetData().RestPatrolTime;
                }
            }

            if (_movementDatas[model].patrolCount >= patrolPoints.Length)
                _movementDatas[model].patrolCount = 0;
        }

        public override void ExitState(EntityModel model)
        {
            model.isPatrolling = false;
            model.Move(Vector3.zero);
        }
    }


}