using System.Collections;
using TarodevController;
using UnityEngine;

public class JumpPowerup : Powerup
{
    [SerializeField] float jumpBuff;

    protected override void BuffStart(GameObject player)
    {
        player.GetComponent<PlayerController>()._stats.JumpPower += jumpBuff;
    }
    protected override void BuffEnd(GameObject player)
    {
        player.GetComponent<PlayerController>()._stats.JumpPower -= jumpBuff;
    }
}
