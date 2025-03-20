using System.Collections;
using UnityEngine;

public class HoveringText : MonoBehaviour
{
    Vector2 basePosition;
    float hoverAmplitude = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basePosition = transform.position;
        StartCoroutine(Hover());
    }

    IEnumerator Hover()
    {
        while (true)
        {
            transform.position = basePosition + new Vector2(0, Mathf.Sin(Time.time) * hoverAmplitude);

            yield return null;
        }
    }
}
