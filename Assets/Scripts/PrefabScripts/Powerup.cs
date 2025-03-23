using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float buffDuration;
    [SerializeField] Color buffColor;
    [SerializeField] GameObject[] visualGameobjects;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] AudioClip buffSound;

    private Collider2D pickUpCollider;
    private bool hasCollected;
    private Coroutine powerUpCoroutine;

    private void Awake()
    {
        pickUpCollider = GetComponent<Collider2D>();
        EnableVisuals(true);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            powerUpCoroutine = StartCoroutine(BuffCoroutine(other.gameObject));
        }
    }
    void EnableVisuals(bool val)
    {
        foreach (var item in visualGameobjects)
        {
            item.SetActive(val);
        }
    }
    protected virtual void BuffStart(GameObject player) { }
    protected virtual void BuffEnd(GameObject player) { }
    protected IEnumerator BuffCoroutine(GameObject player)
    {
        // Disable powerup pickup
        hasCollected = true;
        EnableVisuals(false);
        pickUpCollider.enabled = false;
        audioSource.PlayOneShot(pickUpSound);
        // Changes vignette color
        EffectManager.Instance?.ChangeVignetteColor(buffColor);
        audioSource.clip = buffSound;
        audioSource.Play();
        BuffStart(player);
        yield return new WaitForSeconds(buffDuration);
        // Sets vignette color back to normal
        EffectManager.Instance?.ChangeVignetteColor(Color.white);
        BuffEnd(player);
        // Re-enable powerup pickup
        hasCollected = false;
        EnableVisuals(true);
        pickUpCollider.enabled = true;
        audioSource.clip = null;

        yield break;
    }
}
