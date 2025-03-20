using UnityEngine;

public class Hazard : MonoBehaviour
{
    bool collided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collided)
        {
            collided = true;
            GameManager.Instance.ResetPlayer(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collided = false;
        }
    }
}
