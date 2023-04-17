using UnityEngine;
using zzzNico.Entities;

namespace zzzNico.FSM_SO_VERSION
{
    public class FsmScript
    {
        private StateData[] _allStateDatas;
        private StateData _currentState;
        readonly EntityModel _entityModel;

        public FsmScript(EntityModel entityModel, StateData initStateData)
        {
            this._entityModel = entityModel;
            _currentState = initStateData;

            _allStateDatas = this._entityModel.GetStates();
            _currentState.State.EnterState(this._entityModel);
        }

        public void UpdateState()
        {
            _currentState.State.ExecuteState(_entityModel);
            CheckForConditions();
        }

        private void ChangeState(StateData nextState)
        {
            _currentState.State.ExitState(_entityModel);

            _currentState = nextState;
            _currentState.State.EnterState(_entityModel);
        }
        private void CheckForConditions()
        {
            for (int i = 0; i < _currentState.StateConditions.Length; i++)
            {
                if (_currentState.StateConditions[i].CompleteCondition(_entityModel))
                {
                    ChangeState(_currentState.ExitStates[i]);
                    break;
                }
            }
        }
    }
}