﻿using System.Collections.Generic;
using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "SearchState", menuName = "_main/States/EnemyStates/SearchState", order = 0)]
    public class SearchState : State
    {
        private class SearchData
        {
            public EnemyModel Model;
            public Vector3 Dir;
            public float Timer;
            
        }

        private Dictionary<EntityModel, SearchData> _searchDatas = new Dictionary<EntityModel, SearchData>();
        public override void EnterState(EntityModel model)
        {
            _searchDatas.Add(model, new SearchData());
            _searchDatas[model].Model = (EnemyModel)model;
            var myModel = _searchDatas[model].Model;
            Vector3 lastViewDir = myModel.GetLastViewDir();
            
            Dictionary<Vector3, int> dirChances = new Dictionary<Vector3, int>();
            Vector3 opositeDir = Quaternion.AngleAxis(90f, Vector3.one) * lastViewDir;
            
            dirChances.Add(lastViewDir, 50);
            dirChances.Add(lastViewDir * -1, 20);
            dirChances.Add(opositeDir, 20);
            dirChances.Add(opositeDir * -1, 20);

            var roulette = new Roulette();
            _searchDatas[model].Dir = roulette.Run(dirChances);

            _searchDatas[model].Timer = myModel.GetData().TimeForSearchPlayer;
            
            
            _searchDatas[model].Model.questionSing.SetActive(true);
            myModel.isSearching = true;
        }
        
        

        public override void ExecuteState(EntityModel model)
        {
            _searchDatas[model].Timer -= Time.deltaTime;
            if (_searchDatas[model].Timer > 0)
            {
                _searchDatas[model].Model.Move(_searchDatas[model].Dir);
            }
            else
            {
                _searchDatas[model].Model.isAllert = false;
            }
        }

        public override void ExitState(EntityModel model)
        {
            
            _searchDatas[model].Model.questionSing.SetActive(false);
            _searchDatas.Remove(model);
            model.isSearching = false;
        }
    }
}