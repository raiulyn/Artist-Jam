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

    void Update()
    {
        trigger.SetActive(isSolid);
        
        if (isSolid && Input.GetKeyDown(KeyCode.Space))
        {
            isSolid = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        
        if (obj.CompareTag("Player") && IsFromBelow(obj))
        {
            isSolid = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject obj = other.gameObject;

        if (obj.CompareTag("Player") && !IsFromBelow(obj))
        {
            isSolid = true;
        } else if (obj.CompareTag("Player") && IsFromBelow(obj))
        {
            isSolid = true;
        }
    }

    bool IsFromBelow(GameObject player)
    {
        float direction = (player.transform.position.y - transform.position.y).normalized;

        return direction > 0 ? true : false;
    }
}
