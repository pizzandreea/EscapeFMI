using UnityEngine;

namespace Game
{
    public class Guardian : MonoBehaviour
    {
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
            Debug.Log("Guardian - Kill player");
        }
    
        private void StartFollowingPlayer()
        {
            Debug.Log("Guardian - start following player");
        }

        private void StopFollowingPlayer()
        {
            Debug.Log("Guardian - stop following player");
        }
    }
}
