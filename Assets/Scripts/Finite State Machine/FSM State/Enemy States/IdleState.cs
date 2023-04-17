using Enemies;
using UnityEngine;

namespace Finite_State_Machine.FSM_State.Enemy_States
{
    public class IdleState<T> : FSMState<T>
    {
        float _counter;
        float _idleCounterMax;
        Enemy _enemy;
        Transform _player;
        Rigidbody _rigidbody;
        FSM<T> _fsm;
        T _patrolInput;
        T _seekInput;
        public IdleState(Enemy enemy, Transform player, Rigidbody rigidbody, float idleCounterMax, FSM<T> fSM, T patrolInput, T seekInput)
        {
            _enemy=enemy;
            _player=player;
            _rigidbody=rigidbody;
            _idleCounterMax=idleCounterMax;
            _fsm=fSM;
            _patrolInput=patrolInput;
            _seekInput=seekInput;
            _counter=_idleCounterMax;
        }
        public override void Awake()
        {
            Debug.Log("IdleState");
        }

        public override void Execute()
        {
            bool _inSight=_enemy.LineOfSight(_player.transform);
            Debug.Log("IdleState Execute");
            _counter-=Time.deltaTime;
            if(_counter>0)
            {            
                Debug.Log("Enemy en if Idle");
                _rigidbody.velocity= new Vector3(0, 0, 0);
                _enemy.LineOfSight(_player.transform);
            }
            if(_inSight==false && _counter<=0)
                _fsm.Transition(_patrolInput);
            else if(_inSight==true)
                _fsm.Transition(_seekInput);

        }

        public override void Sleep()
        {
            Debug.Log("Idle State Sleep");
        }
    }
}
