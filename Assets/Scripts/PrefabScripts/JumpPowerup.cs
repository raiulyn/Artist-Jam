using UnityEngine;

public class JumpPowerup : MonoBehaviour
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
        float oldJump = _stats.JumpPower;

        // Changes vignette color and buffs speed
        EffectManager.Instance.ChangeVignetteColor(buffColor);
        playerStats.JumpPower = speedBuff;

        yield return new WaitForSeconds(buffDuration);

        // Sets speed and vignette color back to normal
        playerStats.JumpPower = oldJump;
        EffectManager.Instance.ChangeVignetteColor(Color.White);

        // Destroys powerup
        Destroy(gameObject);
    }
}
