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

        public void Awake()
        {
            // Make sure we don't end up with more GameManagers in the "Don't destroy on load" scene
            Debug.Log(Instance);
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            Inventory = GetComponent<Inventory>();
            InventoryUIManager = GetComponent<InventoryUIManager>();
            DontDestroyOnLoad(gameObject);
        }

        public void GameOver()
        {
            Debug.Log("merge");

            if(GameOverUI != null)
            {
                GameOverUI.SetActive(true);
            }
        }

        public void Restart()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SceneManager.LoadScene("Floor 0");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}