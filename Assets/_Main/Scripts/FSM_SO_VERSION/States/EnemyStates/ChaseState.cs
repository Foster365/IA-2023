using System.Collections.Generic;
using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel.EnemyRouletteWheel;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "_main/States/EnemyStates/ChaseState", order = 0)]
    public class ChaseState : State
    {
        private class ChaseData
        {
            public EnemyModel Model;
        }
        
        
        
        
        private Dictionary<EntityModel, ChaseData> _entitiesData = new Dictionary<EntityModel, ChaseData>();
        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, new ChaseData());
            
            _entitiesData[model].Model = model as EnemyModel;
            
            //Activo la ruleta dentro del model
            _entitiesData[model].Model.Controller.EnemyRoulette.RouletteAction();

            _entitiesData[model].Model.exclamationSing.SetActive(true);
            _entitiesData[model].Model.isChasing = true;
        }
        
        public override void ExecuteState(EntityModel model)
        {
            
            var steering = _entitiesData[model].Model.Controller.EnemySbController;
            _entitiesData[model].Model.cooldownAttack -= Time.deltaTime;
            Vector3 dir = (steering.SbRouletteSteeringBh.GetDir()).normalized;
            
            if (dir != Vector3.zero)
            {
                _entitiesData[model].Model.Move(dir);
            }
        }


        public override void ExitState(EntityModel model)
        {
            var lastDir = (_entitiesData[model].Model.GetTarget().transform.position -
                           _entitiesData[model].Model.transform.position).normalized;
            _entitiesData[model].Model.SetLastViewDir(lastDir);
            _entitiesData[model].Model.exclamationSing.SetActive(false);
            if (_entitiesData.ContainsKey(model)) _entitiesData.Remove(model);
            
            
            model.isChasing = false;
        }
    }
}
