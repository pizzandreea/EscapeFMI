using UnityEngine;

namespace Game
{
    public class Testing : MonoBehaviour
    {
        [SerializeField] private Transform pfPopupText;

        private void Start()
        {
            Instantiate(pfPopupText, transform.position, Quaternion.identity);
        }
    }
}