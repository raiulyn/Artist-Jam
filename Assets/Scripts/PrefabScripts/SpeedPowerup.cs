using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] float speedBuff;
    [SerializeField] float buffDuration;
    [SerializeField] Color buffColor;

    void OnCollisionEnter2D(collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(buff());
            gameObject.SetActive(false);
        }
    }

    IEnumerator buff(GameObject player)
    {
        // Finds playerstats and makes holder value for regular speed
        ScriptableStats playerStats = player.GetComponent<PlayerController>()._stats;
        float oldSpeed = _stats.MaxSpeed;

        // Changes vignette color and buffs speed
        EffectManager.Instance.ChangeVignetteColor(buffColor);
        playerStats.MaxSpeed = speedBuff;

        yield return new WaitForSeconds(buffDuration);

        // Sets speed and vignette color back to normal
        playerStats.MaxSpeed = oldSpeed;
        EffectManager.Instance.ChangeVignetteColor(Color.White);

        // Destroys powerup
        Destroy(gameObject);
    }
}
