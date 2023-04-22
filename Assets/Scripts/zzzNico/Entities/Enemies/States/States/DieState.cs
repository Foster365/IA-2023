using UnityEngine;
using UnityEngine.SceneManagement;
using State = zzzNico.FSM_SO_VERSION.State;

namespace zzzNico.Entities.Enemies.States.States
{
    [CreateAssetMenu(fileName = "DieState", menuName = "_main/States/EnemyStates/DieState", order = 0)]
    public class DieState : State
    {
        public override void EnterState(EntityModel model)
        {
            model.isDead = true;
            SceneManager.LoadScene("Game Over");
        }

        public override void ExecuteState(EntityModel model)
        {
            model.IsDead();
        }

        public override void ExitState(EntityModel model)
        {
            model.isDead = false;
        }
    }
}