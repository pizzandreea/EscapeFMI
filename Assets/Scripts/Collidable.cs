using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    public UnityEvent<Collider2D> onCollide;

    private BoxCollider2D _boxCollider;
    private readonly List<Collider2D> _collisionHits = new();

    protected virtual void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        _boxCollider.OverlapCollider(filter, _collisionHits);

        foreach (var collider in _collisionHits)
        {
            // Don't self-intersect with other colliders on the same entity
            if (collider.transform.GetInstanceID() == transform.GetInstanceID())
            {
                continue;
            }

            onCollide.Invoke(collider);
        }

        // Clean up the list, as it doesn't get cleaned up automatically
        _collisionHits.Clear();
    }
}