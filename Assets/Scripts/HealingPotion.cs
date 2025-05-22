using System.Collections;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{

    private bool isCollected = false;
    // Added so Each Potion Pick can be Worth a diffrent amount
    private AudioSource audSource;
    PickupManager pickupManager;

    private void Start()
    {
        pickupManager = FindAnyObjectByType<PickupManager>();
        audSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isCollected && collision.CompareTag("Player"))
        {
            // Add the potion sprite to the currently selected inventory slot
            pickupManager.AddPotions();
            audSource.Play();
            // Destroy the Potion game object after collection
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(audSource.clip.length);
        Destroy(gameObject);
    }
}


