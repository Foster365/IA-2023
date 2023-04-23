using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Player;
using _Main.Scripts.Steering_Behaviours.Steering_Behaviours;
using UnityEngine;

namespace _Main.Scripts.Steering_Behaviours
{
    public class SBController
    {

        EnemyModel enemyModel;
        PlayerModel target;

        #region Steering Behaviours Variables
        Seek sbSeek;
        Pursuit sbPursuit;
        float pursuitTime;
        Vector3 sbRouletteDir;

        public Vector3 SbRouletteDir { get => sbRouletteDir; set => sbRouletteDir = value; }
        #endregion

        public SBController(EnemyModel _enemyModel, float _pursuitTime)
        {
            enemyModel = _enemyModel;
            target = _enemyModel.GetTarget();
            pursuitTime = _pursuitTime;
            InitializeSB();
        }

        void InitializeSB()
        {
            sbSeek = new Seek(enemyModel.transform, target.transform);
            sbPursuit = new Pursuit(enemyModel.transform, target, pursuitTime);
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
