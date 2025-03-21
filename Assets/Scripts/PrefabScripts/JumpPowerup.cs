using System.Collections;
using TarodevController;
using UnityEngine;

public class JumpPowerup : MonoBehaviour
{
    [SerializeField] float jumpBuff;
    [SerializeField] float buffDuration;
    [SerializeField] Color buffColor;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(buff(other.gameObject));
            gameObject.SetActive(false);
        }
    }

    IEnumerator buff(GameObject player)
    {
        // Finds playerstats and makes holder value for regular speed
        ScriptableStats playerStats = player.GetComponent<PlayerController>()._stats;
        float oldJump = playerStats.JumpPower;

        // Changes vignette color and buffs speed
        EffectManager.Instance.ChangeVignetteColor(buffColor);
        playerStats.JumpPower = jumpBuff;

        yield return new WaitForSeconds(buffDuration);

        // Sets speed and vignette color back to normal
        playerStats.JumpPower = oldJump;
        EffectManager.Instance.ChangeVignetteColor(Color.white);

        // Destroys powerup
        Destroy(gameObject);
    }
}
