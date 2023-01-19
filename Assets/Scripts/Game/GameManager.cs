using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public Inventory inventory;
        public Boolean isGameOver;
        public SoundManager soundManager;
        private void Awake()
        {
            // Make sure we don't end up with more GameManagers in the "Don't destroy on load" scene
            if (Instance != null)
            {
                Destroy(gameObject);

                return;
            }

            Instance = this;
            inventory = GetComponent<Inventory>();
            soundManager = GetComponent<SoundManager>();
            DontDestroyOnLoad(gameObject);
        }

        public void Restart()
        {
            inventory.Clear();
            isGameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}