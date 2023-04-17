using Player;
using UnityEngine;

namespace Environment
{
    public class WreckingBall : MonoBehaviour
    {
        bool hit=false;
        PlayerMC _player;

        private void Update()
        {
            if(hit==true)
                _player.GetDamage(10);
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag=="Player")
            {
                hit=true;
            }
        }
    }
}
