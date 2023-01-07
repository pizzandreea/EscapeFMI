using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [ExecuteInEditMode]
    public class PlayerHeartsUIManager : MonoBehaviour
    {
        // To be dragged in from the inspector
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite halfHeart;
        public Sprite emptyHeart;
        public GameObject player;

        private Health _playerHealth;

        private const int MaxHearts = 5;
        private int _halfHeartToHealthValue;

        public void Start()
        {
            _playerHealth = player.GetComponent<Health>();
            _halfHeartToHealthValue = _playerHealth.maxHealth / MaxHearts / 2;
        }

        public void Update()
        {

            var numOfHalfHearts = _playerHealth.health / _halfHeartToHealthValue;
            var numOfFullHearts = numOfHalfHearts / 2;
            var hasHalfHeart = numOfHalfHearts % 2 == 1;

            for (var i = 0; i < hearts.Length; i++)
            {
                if (i < numOfFullHearts)
                {
                    hearts[i].sprite = fullHeart;
                }
                else if (i == numOfFullHearts && hasHalfHeart)
                {
                    hearts[i].sprite = halfHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }
    }
}