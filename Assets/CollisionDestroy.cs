using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer != 6 && collision.gameObject.layer != 9 && collision.gameObject.layer != 11) { 
            Destroy(gameObject);
        }
    }
}
