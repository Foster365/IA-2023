using UnityEngine;

namespace _Main.Scripts.Utilities
{
    public class GameManager : MonoBehaviour
    {
        Timer timer;

        private void Awake()
        {
            timer = GetComponent<Timer>();
        }
        private void Update()
        {
            timer.RunTimer();
        }
    }
}
