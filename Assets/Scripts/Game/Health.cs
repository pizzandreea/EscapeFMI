using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Health : MonoBehaviour
    {
        public int maxHealth = 100;
        public UnityEvent onDeath;

        public int health;

        void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            health = Mathf.Max(0, health - damage);

            if (health == 0)
            {
                onDeath.Invoke();
            }
        }

        public void Heal(int amount)
        {
            health = Mathf.Min(100, health + amount);
        }

        [Button("Debug - Take damage")]
        private void DebugTakeDamage()
        {
            TakeDamage(Random.Range((int)(20.0 / 100 * maxHealth), (int)(40.0 / 100 * maxHealth)));
        }

        [Button("Debug - Heal")]
        private void DebugHeal()
        {
            Heal(Random.Range((int)(10.0 / 100 * maxHealth), (int)(30.0 / 100 * maxHealth)));
        }
    }
}