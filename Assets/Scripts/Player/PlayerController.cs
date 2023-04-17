using Finite_State_Machine;
using Finite_State_Machine.FSM_State.Player_States;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
    
        FSM<string> _playerFSM;
        PlayerMC _player;
        public Rigidbody _rigidbody;
        PlayerAnimation _playerAnimation;
    
        // ActionNode isDead = new ActionNode(_player.GetDamage);
        // ActionNode playFSM = new ActionNode(_fsm.OnUpdate);
        // _dicNodes.Add(isDead, 100);
        // _dicNodes.Add(playFSM, 20);

        private void Awake()
        {
            _rigidbody=GetComponent<Rigidbody>();
            _player=GetComponent<PlayerMC>();
            _playerAnimation=GetComponent<PlayerAnimation>();
        }
        private void Start()
        {
            _playerFSM=new FSM<string>();

            IdleStatePlayer<string> idleState=new IdleStatePlayer<string>(_rigidbody);
            MoveStatePlayer<string> moveState=new MoveStatePlayer<string>(_player, _rigidbody);
            JumpStatePlayer<string> jumpState=new JumpStatePlayer<string>(_player, _playerAnimation, _rigidbody);

            idleState.AddTransition("MoveState", moveState);
            moveState.AddTransition("IdleState", idleState);
            idleState.AddTransition("JumpState", jumpState);
            jumpState.AddTransition("IdleState", idleState);
            _playerFSM.SetInit(idleState);

        }

        private void Update()
        {
            var h=Input.GetAxis("Horizontal");
            var v=Input.GetAxis("Vertical");
            if(h != 0 || v!= 0)//Agregar grounded
            {
                // Debug.Log("Player in Move");
                _playerFSM.Transition("MoveState");
            }
            if(Input.GetAxis("Jump")==1)
            {
                // Debug.Log("Player in Jump");
                _playerFSM.Transition("JumpState");
            }
            if(h == 0 && v == 0&&_rigidbody.velocity.y==0)
            {
                // Debug.Log("Player Idle");
                _playerFSM.Transition("IdleState");
            }
            _playerFSM.OnUpdate();
        }
    }
}
