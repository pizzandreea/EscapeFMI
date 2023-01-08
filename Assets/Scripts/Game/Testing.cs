using UnityEngine;

namespace Game
{
    public class Testing : MonoBehaviour
    {
        private void Start()
        {
            PopupText.Create(transform.position, "300");
        }
    }
}