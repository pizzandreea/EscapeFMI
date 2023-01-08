using TMPro;
using UnityEngine;

namespace Game
{
    public class PopupText : MonoBehaviour
    {
        private TextMeshPro textMesh;

        public static PopupText Create(Vector3 position, string text)
        {
            var damagePopupTransform = Instantiate(GameAssets.instance.pfPopupText, position, Quaternion.identity);
            var damagePopup = damagePopupTransform.GetComponent<PopupText>();
            damagePopup.Setup(text);

            return damagePopup;
        }

        private void Awake()
        {
            textMesh = transform.GetComponent<TextMeshPro>();
        }

        private void Setup(string text)
        {
            textMesh.SetText(text);
        }
    }
}