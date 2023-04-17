using System;
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Player
{
    public class Player_Controller : MonoBehaviour
    {
        FsmScript playerFSM;
        [SerializeField] StateData initialState;
        private StateData _currentState;
        private EntityModel _model;

        private void Awake()
        {
            _model = GetComponent<PlayerModel>().GetModel();
        }
        private void Start()
        {
            playerFSM = new FsmScript(_model, initialState);
        }
        private void Update()
        {
            //_currentState.State.ExecuteState(_model);
            playerFSM.UpdateState();
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");

            Vector3 dir = new Vector3(horizontalInput, 0, verticalInput);

            if (horizontalInput != 0 || verticalInput != 0)
            {
                _model.isWalking = true;
                _model.isIdle = false;
            }
            else
            {
                _model.isWalking = false;
                _model.isIdle = true;
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