using System;
using UnityEngine;

namespace Game
{
    public class Floating : MonoBehaviour
    {
        private const float Speed = 2.0f;
        private const float Range = 0.005f;

        private Vector3 _originalPosition;

        public void Start()
        {
            _originalPosition = transform.position;
        }

        public void Update()
        {
            var newY = Mathf.Sin(Time.time * Speed) * Range + _originalPosition.y;
            transform.position = new Vector3(_originalPosition.x, newY, _originalPosition.z);
        }
    }
}
