using Enemies;
using Foster.Steering_Behaviours.Steering_Behaviours;
using UnityEngine;

namespace Finite_State_Machine.FSM_State.Enemy_States
{
    public class SeekState<T> : FSMState<T>
    {
        float _patrolDistance;
        float _attackDistance;
        Enemy _enemy;
        ISteeringBehaviour _sBehaviour;
        Transform _target;
        FSM<T> _fsm;
        T _patrolInput;
        T _attackInput;
        public SeekState(Enemy enemy, float patrolDistance, float attackDistance, Transform target, ISteeringBehaviour sBehaviour, FSM<T> fSM, T patrolInput, T attackInput)
        {
            _enemy=enemy;
            _patrolDistance=patrolDistance;
            _attackDistance=attackDistance;
            _sBehaviour=sBehaviour;
            _target=target;
            _fsm=fSM;
            _patrolInput=patrolInput;
            _attackInput=attackInput;
        }

        public override void Awake()
        {
            Debug.Log("SeekState Awake");
        }
        public override void Execute()
        {
            float dist=Vector3.Distance(_enemy.transform.position, _target.transform.position);
            _enemy.Move(_sBehaviour.GetDir());//Chequeo dos distancias
            if(dist <= _attackDistance)
            {
                Debug.Log("Trans to Attack");
                _fsm.Transition(_attackInput);
            }
            else if (dist > _patrolDistance)
            {
                _fsm.Transition(_patrolInput);
            }
        }

        public override void Sleep()
        {
            Debug.Log("SeekState Sleep");
        }
    }
}
