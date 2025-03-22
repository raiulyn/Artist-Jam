using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PhasePlatform : MonoBehaviour
{
    bool isSolid = false;
    GameObject trigger;

    void Start()
    {
        trigger = transform.GetChild(0).gameObject;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        
        if (obj.CompareTag("Player") && IsFromBelow(obj))
        {
            isSolid = false;
            trigger.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (obj.CompareTag("Player") && !IsFromBelow(obj))
        {
            isSolid = true;
            trigger.SetActive(true);
        }
    }

    bool IsFromBelow(GameObject player)
    {
        float direction = (player.transform.position.y - transform.position.y).normalized;

        return direction > 0 ? true : false;
    }
}
