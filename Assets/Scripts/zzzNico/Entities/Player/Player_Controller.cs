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
        private PlayerModel _model;

        private void Awake()
        {
            _model = GetComponent<PlayerModel>();
        }
        private void Start()
        {
            playerFSM = new FsmScript(_model, initialState);
        }
        private void Update()
        {
            _model.CheckGround();
            Debug.Log("Is grounded? " + _model.IsGrounded);

            playerFSM.UpdateState();
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                _model.isWalking = true;
                _model.isIdle = false;
                _model.isJumping = false;
            }
            else
            {
                _model.isWalking = false;
                _model.isIdle = true;
                _model.isJumping = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) /*&& _model.IsGrounded*/)
            {
                Debug.Log("Jump key pressed");
                _model.isWalking = false;
                _model.isIdle = false;
                _model.isJumping = true;
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