using zzzNico.Entities;
using zzzNico.Entities.Enemies;
using zzzNico.FSM_SO_VERSION;

namespace _main.Scripts.ScriptableObjects.FSM.Base
{
    public class FsmScript
    {
        private StateData[] allStateDatas;
        private StateData currentState;
        readonly EntityModel entityModel;

        public FsmScript(EntityModel _entityModel, StateData _initStateData)
        {
            entityModel = _entityModel;
            currentState = _initStateData;

            allStateDatas = entityModel.GetStates();
            currentState.State.EnterState(entityModel);
        }

        public void UpdateState()
        {
            currentState.State.ExecuteState(entityModel);
            CheckForConditions();
        }

        private void ChangeState(StateData nextState)
        {
            currentState.State.ExitState(entityModel);

            //chequear si el exit del state realmente finalizo

            currentState = nextState;
            currentState.State.EnterState(entityModel);
        }
        private void CheckForConditions()
        {
            for (int i = 0; i < currentState.StateConditions.Length; i++)
            {
                if (currentState.StateConditions[i].CompleteCondition(entityModel))
                {
                    ChangeState(currentState.ExitStates[i]);
                    break;
                }
            }
        }
    }
}