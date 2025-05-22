using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    private bool isCollected = false;
    private AudioSource audioSource;
    PickupManager pickupManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pickupManager = FindAnyObjectByType<PickupManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true; // Mark as collected to prevent multiple triggers
            pickupManager.AddCoin();
            audioSource.Play(); // Play the coin collection sound
            StartCoroutine(DestroyAfterSound()); // Destroy the coin after the sound plays
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject); // Destroy the coin after the sound has played
    }
}
