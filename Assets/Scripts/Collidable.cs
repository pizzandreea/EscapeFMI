using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;

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

            OnCollide(collider);
        }

        // Clean up the list, as it doesn't get cleaned up automatically
        _collisionHits.Clear();
    }

    protected virtual void OnCollide(Collider2D collider)
    {
        Debug.Log("OnCollide() isn't implemented in " + name);
    }
}