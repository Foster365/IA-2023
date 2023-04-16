using _main.Scripts.ScriptableObjects.FSM.Base;
using System;
using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies
{
    public class Enemy_Controller : MonoBehaviour
    {

        EnemyModel _model;
        FsmScript enemyFSM;
        [SerializeField] StateData initState;
        [SerializeField] float sbPursuitTime;
        SBController enemySbController;

        public SBController EnemySbController { get => enemySbController; set => enemySbController = value; }

        private void Awake()
        {
            _model = (EnemyModel)GetComponent<EnemyModel>().GetModel();
        }
        private void Start()
        {
            enemyFSM = new FsmScript(_model, initState);
            enemySbController = new SBController(_model, sbPursuitTime);

        }
        private void Update()
        {
            enemyFSM.UpdateState();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_model.isPatrolling)
                {
                    _model.isPatrolling = true;
                    _model.isIdle = false;
                }
                else
                {
                    _model.isPatrolling = false;
                    _model.isIdle = true;
                }

            }

        }
    }
}