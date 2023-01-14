using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject GameOverUI;
        public Inventory Inventory;

        private void Awake()
        {
            // Make sure we don't end up with more GameManagers in the "Don't destroy on load" scene
            if (Instance != null)
            {
                Destroy(gameObject);

                return;
            }

            Instance = this;
            Inventory = GetComponent<Inventory>();
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }

        public void ShowGameOverScreen()
        {
            GameOverUI.SetActive(true);
        }

        private void Restart()
        {
            Inventory.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}