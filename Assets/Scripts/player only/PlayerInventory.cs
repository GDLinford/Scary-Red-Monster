using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int keyCount = 0; // Current number of keys the player has
    public int potCount = 0;
    Inventory inventoryUI;
    HealingPotion hPot;

    // Method to add a key to the player's inventory
    private void Start()
    {
        inventoryUI = GetComponent<Inventory>();
        hPot = FindAnyObjectByType<HealingPotion>();
    }

    // Method to get the current key count
    public int GetKeyCount()
    {
        return keyCount;
    }

    // Method to check if the player has at least one key
    public bool HasKey()
    {
        return keyCount > 0;
    }

 

}