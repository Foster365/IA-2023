using System;
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Player
{
    public class Player_Controller : MonoBehaviour
    {
        
        private StateData _currentState;
        private EntityModel _model;

        private void Awake()
        {
            _model = GetComponent<PlayerModel>().GetModel();
        }

        private void Update()
        {
            _currentState.State.ExecuteState(_model);
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