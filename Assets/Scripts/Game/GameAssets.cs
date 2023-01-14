using UnityEngine;

namespace Game
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets _instance;

        public static GameAssets instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
                }

                return _instance;
            }
        }

        public Transform pfPopupText;
    }
}