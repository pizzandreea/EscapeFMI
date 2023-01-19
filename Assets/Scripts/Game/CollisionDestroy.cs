using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("coll");
        if (collision.gameObject.layer != 6 && collision.gameObject.layer != 11  && collision.gameObject.layer != 12) { 
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 10) {
            Game.Health healthScript = collision.gameObject.GetComponent<Game.Health>();
            healthScript.TakeDamage(25,false);
            if(healthScript.health <= 0) {
                Destroy(collision.gameObject);
            }
                

        }
    }
}
