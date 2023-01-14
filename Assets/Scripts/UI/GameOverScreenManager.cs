using System;
using Game;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class GameOverScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverScreen;

        private bool _lastHandledGameOverState;

        private void Update()
        {
            if (GameManager.Instance.isGameOver != _lastHandledGameOverState)
            {
                gameOverScreen.SetActive(GameManager.Instance.isGameOver);
            }
            if (GameManager.Instance.isGameOver)
            {
                HandleRestartKey();
            }
            
            _lastHandledGameOverState = GameManager.Instance.isGameOver;
        }

        private void HandleRestartKey()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.Restart();
            }
        }
    }
}