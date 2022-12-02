using UnityEngine;

public class Inventory : MonoBehaviour
{
    public void PickUp(Item item)
    {
        Debug.Log("Picked up " + item.name);
        Destroy(item.gameObject);
    }
}