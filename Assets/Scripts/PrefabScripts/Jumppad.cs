using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Jumppad : MonoBehaviour
{
    [SerializeField] float boostForce;
    bool hit = false;

    void BoostPlayer(GameObject player)
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, boostForce));
    }
    
    void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !hit)
        {
            hit = true;
            BoostPlayer(other.gameObject);
        }
    }

    void OnColisionExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hit = false;
        }
    }
}
