using UnityEditorInternal;
using UnityEngine;
using State = zzzNico.FSM_SO_VERSION.State;

namespace zzzNico.Entities.Enemies.States.Die
{
    [CreateAssetMenu(fileName = "DieState", menuName = "_main/States/EnemyStates/DieState", order = 0)]
    public class DieState : State
    {
        public override void ExecuteState(EntityModel model)
        {
            model.Die();
        }
    }
}