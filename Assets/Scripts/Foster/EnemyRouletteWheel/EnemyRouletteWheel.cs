using System.Collections.Generic;
using Roulette_Wheel;
using Tree;
using zzzNico.Entities;
using zzzNico.Entities.Enemies;

namespace Foster.EnemyRouletteWheel
{
    public class EnemyRouletteWheel : EntityRouletteWheel
    {
        Roulette sbRouletteWheel;
        Dictionary<ActionNode, int> sbRouletteWheelNodes = new Dictionary<ActionNode, int>();
        ActionNode sbRouletteInitNode;
        EntityModel model;
        Enemy_Controller enemyController;
        //TODO: Setear en Enemy Controller un EnemyRouletteWheel obj y pasarle los par�metros al inicializar
        public EnemyRouletteWheel(EntityModel _model, Enemy_Controller _enemyController) : base(_model)
        {
            model = _model;
            enemyController = _enemyController;
        }

        public Roulette SbRouletteWheel { get => sbRouletteWheel; set => sbRouletteWheel = value; }
        public Dictionary<ActionNode, int> SbRouletteWheelNodes { get => sbRouletteWheelNodes; set => sbRouletteWheelNodes = value; }
        public ActionNode SbRouletteInitNode { get => sbRouletteInitNode; set => sbRouletteInitNode = value; }

        private void Update()
        {

        }

        public override void CreateRouletteWheel()
        {
            sbRouletteWheel = new Roulette();

            ActionNode sbSeek = new ActionNode(GetSeekDir);
            ActionNode sbPursuit = new ActionNode(GetPursuitDir);
            ActionNode transtoPatrol = new ActionNode(GetTransitionToPatrol);

            sbRouletteWheelNodes.Add(sbSeek, 35);
            sbRouletteWheelNodes.Add(sbPursuit, 40);
            sbRouletteWheelNodes.Add(transtoPatrol, 10);

            ActionNode rouletteAction = new ActionNode(RouletteAction);
        }

        #region Action Nodes

        void SbRouletteAction()
        {
            ActionNode sbNodeRoulette = sbRouletteWheel.Run(sbRouletteWheelNodes);
            sbNodeRoulette.Execute();
        }

        void GetSeekDir()
        {
            enemyController.EnemySbController.GetSeekDir();
        }

        void GetPursuitDir()
        {
            enemyController.EnemySbController.GetPursuitDir();
        }

        void GetTransitionToPatrol()
        {
            model.isPatrolling = true;
        }


        void RouletteAction()
        {
            INode node = sbRouletteWheel.Run(sbRouletteWheelNodes);
            node.Execute();
        }

        #endregion

    }
}
