using Foster.Steering_Behaviours.Steering_Behaviours;
using UnityEngine;
using zzzNico.Entities.Enemies;
using zzzNico.Entities.Player;

namespace Foster.Steering_Behaviours
{
    public class SBController
    {
        
        EnemyModel enemyModel;
        PlayerModel target;

        #region Steering Behaviours Variables
        Seek sbSeek;
        Pursuit sbPursuit;
        public ObstacleAvoidance obstacleAvoidance;
        float pursuitTime;
        Vector3 sbRouletteDir;


        public int maxObs;
        public LayerMask obsMask;
        public float obsAngle;
        public float obsRadius;

        public Vector3 SbRouletteDir { get => sbRouletteDir; set => sbRouletteDir = value; }
        #endregion

        public SBController(EnemyModel _enemyModel, float _pursuitTime, int _maxObs, LayerMask  _obsMask, float _obsAngle, float _obsRadius)
        {
            enemyModel = _enemyModel;
            target = _enemyModel.GetTarget();
            pursuitTime = _pursuitTime;
            maxObs = _maxObs;
            obsMask = _obsMask;
            obsAngle = _obsAngle;
            obsRadius = _obsRadius;
            InitializeSB();
        }

        void InitializeSB()
        {
            sbSeek = new Seek(enemyModel.transform, target.transform);
            sbPursuit = new Pursuit(enemyModel.transform, target, pursuitTime);
            obstacleAvoidance = new ObstacleAvoidance(enemyModel.transform, obsMask, maxObs, obsAngle, obsRadius);
        }

        public void GetSeekDir()
        {
            sbRouletteDir = sbSeek.GetDir();
        }

        public void GetPursuitDir()
        {
            sbRouletteDir = sbSeek.GetDir();
        }

    }
}
