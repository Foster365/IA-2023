using System;
using UnityEngine;
using zzzNico.Entities;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico
{
    public class BhTree
    {
        
        private StateData[] _stateDatas;
        private StateData _currentState;
        private EntityModel _model;

        public BhTree(StateData[] stateDatas, EntityModel model)
        {
            _stateDatas = stateDatas;
            _model = model;
        }
        public void InitializeBhTree()
        {
            _currentState = _stateDatas[0];
            _model.ChangeState(_currentState);
        }
        
        
        public void CheckChangeConditions(EntityModel model)
        {
            for (int i = 0; i < _currentState.StateConditions.Length; i++)
            {
                if (_currentState.StateConditions[i].CompleteCondition(model))
                {
                    model.ChangeState(_currentState.ExitStates[i]);
                    break;
                }
            }
        }
        
    }
}