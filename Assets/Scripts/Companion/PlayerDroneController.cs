using System.Collections.Generic;
using Roulette_Wheel;
using Tree;
using UnityEngine;

namespace Companion
{
    public class PlayerDroneController : MonoBehaviour
    {
        PlayerDrone _playerDrone;
        Roulette _roulette;
        Dictionary<string, int> _dictionary;
        Dictionary<INode,int> _nodesDictionary=new Dictionary<INode, int>();
        INode _initNode;
        public Rigidbody player;

        private void Awake()
        {
            _playerDrone=GetComponent<PlayerDrone>();
        }

        private void Start()
        {

            _roulette=new Roulette();

            ActionNode dead= new ActionNode(_playerDrone.Dead);
            ActionNode follow= new ActionNode(_playerDrone.FollowPlayer);
            ActionNode heal=new ActionNode(_playerDrone.Healing);
        
            ActionNode successfullHealing= new ActionNode(_playerDrone.Healing);
            ActionNode partiallyHealing=new ActionNode(_playerDrone.PartialHealing);
            ActionNode failHealing= new ActionNode(_playerDrone.FailHeaing);
        
            // _nodesDictionary.Add(dead, 10);
            // _nodesDictionary.Add(follow, 80);
            _nodesDictionary.Add(successfullHealing,60);
            _nodesDictionary.Add(partiallyHealing, 30);
            _nodesDictionary.Add(failHealing, 40);

            ActionNode rouletteAction= new ActionNode(RouletteAction);
        
            QuestionNode playerLowLife = new QuestionNode(_playerDrone.PlayerLowLife, heal, follow);
            QuestionNode hasLife = new QuestionNode(_playerDrone.IsAlive, playerLowLife, dead);
            _initNode=hasLife;

        }

        private void Update()
        {
            if(player.velocity.x!=0&&player.velocity.z!=0)
            {
                Debug.Log("Entering in Tree");
                _initNode.Execute();
            }
        }
        void RouletteAction()
        {
            INode node = _roulette.Run(_nodesDictionary);
            node.Execute();
        }
    }
}
