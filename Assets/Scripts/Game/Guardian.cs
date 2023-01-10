using UnityEngine;
using Pathfinding;

namespace Game
{
    public class Guardian : MonoBehaviour
    {
        public Player player;
        public GameManager GameManager;
        public AIPath aIPath;
        Vector2 direction;

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

        public void HandleLeaveProximity(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                StopFollowingPlayer();
            }
        }

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

            aIPath = GetComponent<AIPath>();
            aIPath.canMove = true;
        }

        private void StopFollowingPlayer()
        {
            Debug.Log("Guardian - stop following player");
            aIPath.canMove = false;
        }
    }
}
