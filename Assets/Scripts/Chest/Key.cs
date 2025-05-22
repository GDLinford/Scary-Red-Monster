using System.Collections;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isCollected = false;
    private AudioSource auSource;
    PickupManager puManager;

    private void Start()
    {
        auSource = GetComponent<AudioSource>();
        puManager = FindAnyObjectByType<PickupManager>();
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (!isCollected && collison.CompareTag("Player")) 
        { 
            isCollected = true;
            puManager.AddKeys();
            auSource.Play();
            StartCoroutine(DestroyAfterSound());
            
        }
        
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(auSource.clip.length);
        Destroy(gameObject);
    }
}