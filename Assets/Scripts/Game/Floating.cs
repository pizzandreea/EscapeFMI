using UnityEngine;

namespace Game
{
    public class Floating : MonoBehaviour
    {
        private const float Speed = 2.5f;
        public static float Range = 0.00007f;

        public void Update()
        {
            Vector3 currentPosition = transform.position;
            var newY = Mathf.Sin(Time.time * Speed) * Range + currentPosition.y;
            transform.position = new Vector3(currentPosition.x, newY, currentPosition.z);
        }
    }
}