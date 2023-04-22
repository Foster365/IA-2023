using Enemies;
using UnityEngine;

namespace zzzNico.Entities.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public ParticleSystem muzzleFlash;
        EnemyAnimation _enemyAnimation;


        private void Awake()
        {
            _enemyAnimation = GetComponent<EnemyAnimation>();
        }

        public void PlayRunAnimation(EnemyModel model)
        {
            _enemyAnimation.RunningAnim(model.GetRigidbody().velocity.magnitude);
        }
    }
}