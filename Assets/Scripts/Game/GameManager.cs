using UI;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Inventory Inventory;
        public InventoryUIManager InventoryUIManager;

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
            DontDestroyOnLoad(gameObject);
        }
    }
}