using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class ProximityDetector : MonoBehaviour
    {
        public ContactFilter2D filter;
        public UnityEvent<Collider2D> onEnterProximity;
        public UnityEvent<Collider2D> onLeaveProximity;

        private CircleCollider2D _proximityCollider2D;
        private readonly List<Collider2D> _proximityHits = new();
        private readonly HashSet<Collider2D> _inProximity = new();

        protected virtual void Start()
        {
            _proximityCollider2D = GetComponent<CircleCollider2D>();
        }

        protected virtual void Update()
        {
            _proximityCollider2D.OverlapCollider(filter, _proximityHits);

            CheckObjectsAlreadyInProximity();
            CheckForNewObjectsInProximity();

            // Clean up the list, as it doesn't get cleaned up automatically
            _proximityHits.Clear();
        }

        private void CheckObjectsAlreadyInProximity()
        {
            var leftProximity = new HashSet<Collider2D>();

            foreach (var collider in _inProximity)
            {
                if (!_proximityHits.Contains(collider))
                {
                    leftProximity.Add(collider);
                }
            }

            foreach (var collider in leftProximity)
            {
                onLeaveProximity.Invoke(collider);
                _inProximity.Remove(collider);
            }
        }

        private void CheckForNewObjectsInProximity()
        {
            foreach (var collider in _proximityHits)
            {
                // Don't self-intersect with other colliders on the same entity
                if (collider.transform.GetInstanceID() == transform.GetInstanceID())
                {
                    continue;
                }

                // Ignore objects already in proximity
                if (_inProximity.Contains(collider))
                {
                    continue;
                }

                onEnterProximity.Invoke(collider);
                _inProximity.Add(collider);
            }
        }
    }
}