using TMPro;
using UnityEngine;

namespace Game
{
    public class PopupText : MonoBehaviour
    {
        private const float MoveYSpeed = 0.25f;
        private const float DisappearSpeed = 3.0f;
        private const float DisappearTime = 0.5f;
        private const float FontSize = 36.0f;

        private TextMeshPro _textMesh;
        private Color _textColor;
        private float _disappearTimer = DisappearTime;

        public static PopupText Create(Vector3 position, string text, Color color, float scale = 1.0f)
        {
            var damagePopupTransform = Instantiate(GameAssets.instance.pfPopupText, position, Quaternion.identity);
            var damagePopup = damagePopupTransform.GetComponent<PopupText>();
            damagePopup.Setup(text, color, scale);

            return damagePopup;
        }

        private void Awake()
        {
            _textMesh = transform.GetComponent<TextMeshPro>();
        }

        private void Setup(string text, Color color, float scale)
        {
            _textMesh.fontSize = FontSize;
            _textMesh.SetText(text);
            _textMesh.color = color;
            _textMesh.fontSize *= scale;

            _textColor = _textMesh.color;
        }

        private void Update()
        {
            transform.position += new Vector3(0, MoveYSpeed) * Time.deltaTime;
            _disappearTimer -= Time.deltaTime;
            if (_disappearTimer <= 0.0f)
            {
                // Start disappearing
                _textColor.a -= DisappearSpeed * Time.deltaTime;
                _textMesh.color = _textColor;

                if (_textColor.a <= 0.0f)
                {
                    // Disappeared
                    Destroy(gameObject);
                }
            }
        }
    }
}