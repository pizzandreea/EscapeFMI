using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Health : MonoBehaviour
    {
        private readonly Color _damageColorNormal = new(1.0f, 0.77f, 0.0f, 1.0f);
        private readonly Color _damageColorCritical = new(1.0f, 0.16f, 0.0f, 1.0f);
        private readonly Color _healColor = new(0.13f, 0.87f, 0.22f, 1.0f);
        private const float CriticalHitScale = 1.2f;

        public UnityEvent onDeath;
        public int maxHealth = 100;
        public int health;

        private void Awake()
        {
            health = maxHealth;
        }

        public void TakeDamage(int damage, bool isCritical = false)
        {
            if (isCritical)
            {
                damage *= 2;
            }
            health = Mathf.Max(0, health - damage);

            if (!isCritical)
            {
                PopupText.Create(transform.position, damage.ToString(), _damageColorNormal);
            }
            else
            {
                PopupText.Create(transform.position, damage.ToString(), _damageColorCritical, CriticalHitScale);
            }

            if (health <= 0)
            {
                onDeath.Invoke();
            }
        }

        public void Heal(int amount)
        {
            if (health != maxHealth)
            {
                PopupText.Create(transform.position, amount.ToString(), _healColor);
            }

            health = Mathf.Min(maxHealth, health + amount);
        }

        [Button("Debug - Take damage")]
        private void DebugTakeDamage()
        {
            var isCritical = Random.Range(0, 3) == 0;
            TakeDamage(Random.Range((int)(5.0 / 100 * maxHealth), (int)(10.0 / 100 * maxHealth)), isCritical);
        }

        [Button("Debug - Heal")]
        private void DebugHeal()
        {
            Heal(Random.Range((int)(10.0 / 100 * maxHealth), (int)(20.0 / 100 * maxHealth)));
        }
    }
}