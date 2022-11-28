using System;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    public ContactFilter2D filter;

    private CircleCollider2D _proximityCollider2D;
    private readonly Collider2D[] _collisionHits = new Collider2D[25];

    protected virtual void Start()
    {
        _proximityCollider2D = GetComponent<CircleCollider2D>();
    }

    protected virtual void Update()
    {
        _proximityCollider2D.OverlapCollider(filter, _collisionHits);

        for (var i = 0; i < _collisionHits.Length; i++)
        {
            if (_collisionHits[i] == null)
            {
                continue;
            }

            // Don't self-intersect with other colliders on the same entity
            if (_collisionHits[i].transform.GetInstanceID() != transform.GetInstanceID())
            {
                OnProximity(_collisionHits[i]);
            }

            // Clean up the array, as it doesn't get cleaned up automatically
            _collisionHits[i] = null;
        }
    }

    protected virtual void OnProximity(Collider2D collider)
    {
        Debug.Log("OnProximity() isn't implemented in " + name);
    }
}