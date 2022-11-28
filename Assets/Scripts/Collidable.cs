using System;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;

    private BoxCollider2D _boxCollider;
    private readonly Collider2D[] _collisionHits = new Collider2D[25];

    protected virtual void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        _boxCollider.OverlapCollider(filter, _collisionHits);

        for (var i = 0; i < _collisionHits.Length; i++)
        {
            if (_collisionHits[i] == null)
            {
                continue;
            }

            OnCollide(_collisionHits[i]);

            // Clean up the array, as it doesn't get cleaned up automatically
            _collisionHits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D collider)
    {
        Debug.Log("OnCollide() isn't implemented in " + name);
    }
}