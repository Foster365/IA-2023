using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Roulette_Wheel.EnemyRouletteWheel;
using _Main.Scripts.Steering_Behaviours;
using UnityEngine;

namespace _Main.Scripts.Entities.Enemies
{
    public class Enemy_Controller : MonoBehaviour
    {

        EnemyModel _model;
        FsmScript _enemyFsm;
        [SerializeField] StateData initState;
        [SerializeField] float sbPursuitTime;
        SBController enemySbController;
        EnemyRouletteWheel enemyRoulette;

        public SBController EnemySbController { get => enemySbController; set => enemySbController = value; }
        public EnemyRouletteWheel EnemyRoulette { get => enemyRoulette; set => enemyRoulette = value; }

        private void Awake()
        {
            _model = (EnemyModel)GetComponent<EnemyModel>().GetModel();
        }
        private void Start()
        {
            _enemyFsm = new FsmScript(_model, initState);
            enemySbController = new SBController(_model, sbPursuitTime);
            enemyRoulette = new EnemyRouletteWheel(_model, this);

        }
        private void Update()
        {
            _enemyFsm.UpdateState();

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