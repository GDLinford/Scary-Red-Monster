using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PickupManager : MonoBehaviour
{
    //this script will handle picking up, coins, potions and Keys
    public TextMeshProUGUI cointext, hPotText, KeyText;
    [HideInInspector] public int coinCount, hPotCount, KeyCount;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        hPotCount = 0;
        KeyCount = 0;
    }

    public void AddCoin()
    {
        coinCount++;
        UpdatePickupText();
    }

    public void AddPotions()
    {
        hPotCount++;
        UpdatePickupText();
    }

    public void AddKeys()
    {
        KeyCount++;
        UpdatePickupText();
    }

    public void UpdatePickupText()
    {
        cointext.text = "Coins: " + coinCount.ToString();
        hPotText.text = "Healing potions: " + hPotCount.ToString();
        KeyText.text = "Keys: " + KeyCount.ToString();
    }


    public void UsePotion()
    {
        if (hPotCount > 0)
        { 
            hPotCount = hPotCount - 1;
            UpdatePickupText();
        }
        else
        {
            Debug.Log("No more Potions anymore");
        }
    }

    // Method to use a key, reducing the key count by 1
    public void UseKey()
    {
        if (KeyCount > 0)
        {
            KeyCount--;
            UpdatePickupText();
        }
        else
        {
            Debug.Log("No keys left to use.");
        }
    }

}
