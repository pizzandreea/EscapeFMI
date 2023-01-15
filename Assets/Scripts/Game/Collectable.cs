using UnityEngine;

namespace Game
{
    public class Collectable : Collidable
    {
        private Item _item;

        protected override void Start()
        {
            base.Start();

            var spriteRenderer = GetComponent<SpriteRenderer>();
            _item = new Item(name, spriteRenderer.sprite);
            onCollide.AddListener(HandleCollision);
        }

        private void HandleCollision(Collider2D collider)
        {
            if (!collider.CompareTag("Player"))
            {
                return;
            }

            GameManager.Instance.inventory.PickUp(_item);

            //Destroy(gameObject);
            if (gameObject != null)
            {

                gameObject.SetActive(false);

            }

        }
    }
}