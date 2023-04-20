using UnityEngine;
using zzzNico.FSM_SO_VERSION;

namespace zzzNico.Entities.Enemies.States.States
{
    [CreateAssetMenu(fileName = "SearchState", menuName = "_main/States/EnemyStates/SearchState", order = 0)]
    public class SearchState : State
    {
        public override void EnterState(EntityModel model)
        {
            model.isSearching = true;
        }
        
        

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Searching");
        }

        public override void ExitState(EntityModel model)
        {
            model.isSearching = false;
        }
    }
}