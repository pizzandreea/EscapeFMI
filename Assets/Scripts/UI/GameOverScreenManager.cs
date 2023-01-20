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

        private void LateUpdate()
        {
            if (GameManager.Instance.isGameOver != _lastHandledGameOverState)
            {
                gameOverScreen.SetActive(GameManager.Instance.isGameOver);
            }
            if (GameManager.Instance.isGameOver)
            {
                HandleRestartKey();
            }
        }

        private void HandleRestartKey()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _lastHandledGameOverState = GameManager.Instance.isGameOver;
                GameManager.Instance.Restart();
            }
        }
    }
}