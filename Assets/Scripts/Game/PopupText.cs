using TMPro;
using UnityEngine;

namespace Game
{
    public class PopupText : MonoBehaviour
    {
        private TextMeshPro textMesh;
        
        private void Awake()
        {
            textMesh = transform.GetComponent<TextMeshPro>();
        }
        
        public void Setup(int damageAmount)
        {
            textMesh.SetText(damageAmount.ToString());
        }
    }
}