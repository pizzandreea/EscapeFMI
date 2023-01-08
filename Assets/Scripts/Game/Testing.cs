using UnityEngine;

namespace Game
{
    public class Testing : MonoBehaviour
    {
        [SerializeField] private Transform pfPopupText;

        private void Start()
        {
            Transform damagePopupTransform = Instantiate(pfPopupText, transform.position, Quaternion.identity);
            PopupText damagePopup = damagePopupTransform.GetComponent<PopupText>();
            damagePopup.Setup(300);
        }
    }
}