using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [ExecuteInEditMode]
    public class HeartsBarUIManager : MonoBehaviour
    {
        // To be dragged in from the inspector
        [SerializeField] private Sprite fullHeart;
        [SerializeField] private Sprite halfHeart;
        [SerializeField] private Sprite emptyHeart;

        private const int MaxHearts = 5;

        private Image[] _hearts;
        private Health _playerHealth;
        private int _halfHeartToHealthValue;

        private void Awake()
        {
            _hearts = new Image[MaxHearts];
            for (var i = 0; i < MaxHearts; i++)
            {
                _hearts[i] = GameObject.Find("Heart - " + i).GetComponent<Image>();
                _hearts[i].sprite = fullHeart;
            }

            _playerHealth = GameObject.Find("Player").GetComponent<Health>();
            _halfHeartToHealthValue = _playerHealth.maxHealth / MaxHearts / 2;
        }

        private void Update()
        {
            var numOfHalfHearts = _playerHealth.health / _halfHeartToHealthValue;
            var numOfFullHearts = numOfHalfHearts / 2;
            var hasHalfHeart = numOfHalfHearts % 2 == 1;

            for (var i = 0; i < _hearts.Length; i++)
            {
                if (i < numOfFullHearts)
                {
                    _hearts[i].sprite = fullHeart;
                }
                else if (i == numOfFullHearts && hasHalfHeart)
                {
                    _hearts[i].sprite = halfHeart;
                }
                else
                {
                    _hearts[i].sprite = emptyHeart;
                }
            }
        }
    }
}