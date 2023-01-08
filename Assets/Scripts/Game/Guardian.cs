using UnityEngine;

namespace Game
{
    public class Guardian : MonoBehaviour
    {
        public Player player;
        public GameManager GameManager;

        public float NormalSpeed = 0.6f;

        public void HandleCollision(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                KillPlayer();
            }
        }

        public void HandleEnterProximity(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                StartFollowingPlayer();
            }
        }

        //public void HandleLeaveProximity(Collider2D collider)
        //{
        //    if (collider.CompareTag("Player"))
        //    {
        //        StopFollowingPlayer();
        //    }
        //}

        private void KillPlayer()
        {
            if(!player.isDead)
            {
                Debug.Log("Guardian - Kill player");
                player.isDead = true;
                GameManager.GameOver();
            }
            
        }
    
        private void StartFollowingPlayer()
        {
            Debug.Log("Guardian - start following player");
            float distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, NormalSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        private void StopFollowingPlayer()
        {
            Debug.Log("Guardian - stop following player");
        }
    }
}
