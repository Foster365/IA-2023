using System;
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies
{
    public class Enemy_Controller : MonoBehaviour
    {
        
        private StateData _currentState;
        private EntityModel _model;
        
        private void Awake()
        {
            _model = GetComponent<EnemyModel>().GetModel();
        }
        
        
        
        
        private void Update()
        {
            _currentState.State.ExecuteState(_model);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_model.isPatrolling)
                {
                    _model.isPatrolling = true;
                    _model.isIdle = false;
                }
                else
                {
                    _model.isPatrolling = false;
                    _model.isIdle = true;
                }
                
            }
            
        }

        public void InitializeState(StateData nextState)
        {
            _currentState = nextState;
            _currentState.State.EnterState(_model);
        }

        public void ExitCurrentState()
        {
            _currentState.State.ExitState(_model);
        }
    }
}