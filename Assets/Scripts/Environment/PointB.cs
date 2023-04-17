using UnityEngine;

namespace Environment
{
    public class PointB : MonoBehaviour
    {
        bool win=false;

        private void Update()
        {
            if(win==true)
                Application.Quit();
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag=="Player")
            {
                win=true;
                Debug.Log("You won, closing...");
            }
        }
    }
}
