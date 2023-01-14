using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject GameOverUI;
        public Inventory Inventory;
        public InventoryUIManager InventoryUIManager;
        public PlayerHeartsUIManager PlayerHeartsUIManager;

        public void Awake()
        {
            // Make sure we don't end up with more GameManagers in the "Don't destroy on load" scene
            if (Instance != null)
            {
                Destroy(gameObject);

                return;
            }

            Instance = this;
            Inventory = GetComponent<Inventory>();
            InventoryUIManager = GetComponent<InventoryUIManager>();
            PlayerHeartsUIManager = GetComponent<PlayerHeartsUIManager>();
            DontDestroyOnLoad(gameObject);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void GameOver()
        {
            if (GameOverUI != null)
            {
                GameOverUI.SetActive(true);
            }
        }

        public void Restart()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}