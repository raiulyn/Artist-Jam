using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.NewCheckpoint(gameObject);
        }
    }
}
