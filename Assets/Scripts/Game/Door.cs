using UnityEngine;

namespace Game
{
    public class Door : MonoBehaviour
    {
        private Inventory _inventory;
        public SpriteRenderer spriteRenderer;
        public Sprite doorOpenSprite;

        public bool doorOpen, waitingToOpen;
        
        public void Start()
        {
            _inventory = GameManager.Instance.inventory;
        }

        private void Update()
        {
            if (waitingToOpen)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    waitingToOpen = false;
                    doorOpen = true;
                    spriteRenderer.sprite = doorOpenSprite;
                    
                    _inventory.UseItem("Key");
                }
            }
            else if (doorOpen)
            {
                spriteRenderer.sprite = doorOpenSprite;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (_inventory.HasItem("Key"))
                {
                    waitingToOpen = true;
                }
            }
        }
    }
}