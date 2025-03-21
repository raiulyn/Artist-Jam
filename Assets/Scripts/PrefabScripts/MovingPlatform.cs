using UnityEngine;
using UnityEngine.EventSystems;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Rigidbody2D rb;
    bool isMovingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime * (isMovingRight ? 1 : -1));

        if (transform.childCount > 1)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.CompareTag("Player"))
                {
                    child.gameObject.GetComponent<Rigidbody2D>().linearVelocity += Vector2.right * speed * Time.fixedDeltaTime * (isMovingRight ? 1 : -1);
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    // Wall Detector Trigger (on child object)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) // Detects walls or barriers
        {
            isMovingRight = !isMovingRight;
        }
    }
}
