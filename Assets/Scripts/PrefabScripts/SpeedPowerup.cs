using System.Collections;
using TarodevController;
using UnityEngine;

public class SpeedPowerup : Powerup
{
    [SerializeField] float speedBuff;

    protected override void BuffStart(GameObject player)
    {
        player.GetComponent<PlayerController>()._stats.MaxSpeed += speedBuff;
    }
    protected override void BuffEnd(GameObject player)
    {
        player.GetComponent<PlayerController>()._stats.MaxSpeed -= speedBuff;
    }
}
