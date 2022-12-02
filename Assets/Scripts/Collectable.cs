using UnityEngine;

public class Collectable : Collidable
{
    private Item _item;
    
    protected override void Start()
    {
        base.Start();
        
        _item = GetComponent<Item>();
        onCollide.AddListener(HandleCollision);
    }

    private void HandleCollision(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
        {
            return;
        }
        
        GameManager.instance.inventory.PickUp(_item);
    }
}