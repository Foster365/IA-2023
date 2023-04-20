using UnityEngine;

namespace Finite_State_Machine.FSM_State.Player_States
{
    public class IdleStatePlayer<T> : FSMState<T>
    {

        Rigidbody _rigidbody;
        public IdleStatePlayer(Rigidbody rigidbody)
        {
            _rigidbody=rigidbody;
        }
        public override void Awake()
        {
            // Debug.Log("IdleState Awake");
        }

        public override void Execute()
        {
        
        }
        public override void Sleep()
        {
            // Debug.Log("IdleState Sleep");
        }
    
    }
}
