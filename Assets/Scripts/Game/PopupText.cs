using TMPro;
using UnityEngine;

namespace Game
{
    public class PopupText : MonoBehaviour
    {
        private const float MoveYSpeed = 0.2f;
        
        private TextMeshPro _textMesh;

        public static PopupText Create(Vector3 position, string text)
        {
            var damagePopupTransform = Instantiate(GameAssets.instance.pfPopupText, position, Quaternion.identity);
            var damagePopup = damagePopupTransform.GetComponent<PopupText>();
            damagePopup.Setup(text);

            return damagePopup;
        }

        private void Awake()
        {
            _textMesh = transform.GetComponent<TextMeshPro>();
        }

        private void Setup(string text)
        {
            _textMesh.SetText(text);
        }

        private void Update()
        {
            transform.position += new Vector3(0, MoveYSpeed) * Time.deltaTime;
        }
    }
}