using Enemies;
using Foster.Steering_Behaviours.Steering_Behaviours;
using UnityEngine;

namespace Finite_State_Machine.FSM_State.Enemy_States
{
    public class PatrolState<T> : FSMState<T>
    {
        float _patrolCounter=0;
        float _counter;
        Transform _target;
        Enemy _enemy;
        ISteeringBehaviour _sBehaviour;

        FSM<T> _fsm;
        T _idleInput;
        T _seekInput;


        // EnemyController _enemyController;
    
        // FSM<T>  _FSM;
        // T _idleState;
        // T _attackState;

        // Transform transform;

        // Vector3 dir;
        //

        public PatrolState(Enemy enemy, Transform target, ISteeringBehaviour sBehaviour, float patrolCounter, FSM<T> fSM, T idleInput, T seekInput)
        {

            _enemy = enemy;
            _target=target;
            _sBehaviour=sBehaviour;
            _patrolCounter=patrolCounter;
            _fsm=fSM;
            _idleInput=idleInput;
            _seekInput=seekInput;
            _counter=patrolCounter;
        }

        public override void Awake()
        {
            Debug.Log("PatrolState Awake");
            _counter=_patrolCounter;
        }

        public override void Execute()
        {
            Debug.Log("PatrolState Execute");
            bool inSight=_enemy.LineOfSight(_target.transform);
            Debug.Log("Entra en for Patrol Execute");
            _counter-=Time.deltaTime;
            if(_counter>0)
            {
                _enemy.GoToWaypoint();
                _enemy.LineOfSight(_target.transform);
                // _enemy.Move(_sBehaviour.GetDir());
            }
        
            if(inSight==false && _counter <= 0)
                _fsm.Transition(_idleInput);
            else if(inSight==true)
                _fsm.Transition(_seekInput);

        }

        public override void Sleep()
        {
            // maxIiterations=0;
            Debug.Log("PatrolState Sleep");
        }

    }
}
