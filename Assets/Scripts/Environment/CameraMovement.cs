using UnityEngine;

namespace Environment
{
    public class CameraMovement : MonoBehaviour
    {

        public float speed;
        public float maxRotation;

        void Update()
        {
            transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * speed), 0f);
        }

    }
}
