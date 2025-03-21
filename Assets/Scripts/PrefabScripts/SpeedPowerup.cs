using System.Collections;
using TarodevController;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    [SerializeField] float speedBuff;
    [SerializeField] float buffDuration;
    [SerializeField] Color buffColor;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Buff(other.gameObject));
            gameObject.SetActive(false);
        }
    }

    IEnumerator Buff(GameObject player)
    {
        Debug.Log("Buff coroutine started");

        // Finds playerstats and makes holder value for regular speed
        ScriptableStats playerStats = player.GetComponent<PlayerController>()._stats;
        float oldSpeed = playerStats.MaxSpeed;

        // Changes vignette color and buffs speed
        EffectManager.Instance.ChangeVignetteColor(buffColor);
        playerStats.MaxSpeed = speedBuff;

        Debug.Log("Speed buff applied");

        yield return new WaitForSeconds(buffDuration);

        Debug.Log("Speed powerup expired");
        // Sets speed and vignette color back to normal
        playerStats.MaxSpeed = oldSpeed;
        EffectManager.Instance.ChangeVignetteColor(Color.white);

        // Destroys powerup
        Destroy(gameObject);
        Debug.Log("Buff coroutine ended");
    }
}
