using Pathfinding;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        // Modify in the inspector
        public int damage = 10;
        public float criticalHitChance = 0.2f;
        public float delayBetweenAttacks = 1.0f;

        private Health _playerHealth;
        private AIPath _aiPath;
        private float _attackTimer;

        public Animator animator;

        [SerializeField] AudioSource awake;

        private void Awake()
        {
            _playerHealth = GameObject.Find("Player").GetComponent<Health>();
            _aiPath = GetComponent<AIPath>();
            _attackTimer = delayBetweenAttacks;
        }

        private void Update()
        {
            _attackTimer -= Time.deltaTime;
            // Moving Up
            if (_aiPath.desiredVelocity.y > 0.0f)
                animator.SetBool("isMovingUp", true);
            else if (_aiPath.desiredVelocity.y < 0.0f)
                animator.SetBool("isMovingUp", false);

            //Moving down
            if (_aiPath.desiredVelocity.y < -0.0f)
                animator.SetBool("isMovingDown", true);
            else if (_aiPath.desiredVelocity.y > 0.0f)
                animator.SetBool("isMovingDown", false);

            // Moving Right
            if (_aiPath.desiredVelocity.x > 0.0f)
                animator.SetBool("isMovingRight", true);
            else if (_aiPath.desiredVelocity.x < 0.0f)
                animator.SetBool("isMovingRight", false);

            // Moving Left
            if (_aiPath.desiredVelocity.x < -0.0f)
                animator.SetBool("isMovingLeft", true);
            else if (_aiPath.desiredVelocity.x > 0.0f)
                animator.SetBool("isMovingLeft", false);

        }

        public void HandleCollision(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                AttackPlayer();
            }
        }

        public void HandleEnterProximity(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                awake.Play();
                StartFollowingPlayer();
            }
        }

        public void HandleLeaveProximity(Collider2D collider)
        {
            if (collider.CompareTag("Player"))
            {
                // In case we want to implement the player getting out of reach
            }
        }

        private void AttackPlayer()
        {
            if (GameManager.Instance.isGameOver)
            {
                return;
            }

            if (CanAttack())
            {
                _playerHealth.TakeDamage(GetRandomDamage(), DidCriticalHit());
                _attackTimer = delayBetweenAttacks;
            }
        }

        private void StartFollowingPlayer()
        {
            _aiPath.canMove = true;
        }

        private bool DidCriticalHit()
        {
            return Random.value <= criticalHitChance;
        }

        private bool CanAttack()
        {
            return _attackTimer <= 0;
        }

        private int GetRandomDamage()
        {
            var noise = (int)(0.25f * damage);
            return Random.Range(damage - noise, damage + noise);
        }
    }
}