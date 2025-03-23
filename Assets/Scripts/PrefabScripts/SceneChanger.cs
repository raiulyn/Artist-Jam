using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string SceneID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManagerr.Instance?.LoadScene(SceneID);
        }
    }
}
