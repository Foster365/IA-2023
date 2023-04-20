using Enemies;
using UnityEngine;

namespace Finite_State_Machine.FSM_State.Enemy_States
{
    public class AttackState<T>:FSMState<T>
    {
        int _bulletDistance;
        LayerMask _layerMask;
        Enemy _enemy;
        Transform _target;
        FSM<T> _fsm;
        T _seekInput;

        public AttackState(Enemy enemy, Transform target, LayerMask layerMask, int bulletDistance, FSM<T> fsm, T seekInput)
        {
            _bulletDistance=bulletDistance;
            _layerMask=layerMask;
            _enemy = enemy;
            _target=target;
            _fsm=fsm;
            _seekInput=seekInput;
        }

        public override void Awake()
        {
            Debug.Log("SeekState Awake");
        }

        public override void Execute()
        {        
            float dist=Vector3.Distance(_enemy.transform.position, _target.transform.position);

            Debug.Log("Attacking player");
            _enemy.Attack(/*_target, _bulletDistance, _layerMask*/);
            if(dist>_bulletDistance)
                _fsm.Transition(_seekInput);
        }

        public override void Sleep()
        {
            Debug.Log("SeekState Sleep");
        }
    }
}
