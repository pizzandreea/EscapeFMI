using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public Inventory inventory;

        public void Awake()
        {
            // Make sure we don't end up with more GameManagers in the "Don't destroy on load" scene
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            inventory = GetComponent<Inventory>();
        }
    }
}