using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TutoiralScript : MonoBehaviour
{
    [SerializeField] int collidedCount = 0;
    [SerializeField] TextMeshProUGUI[] tutorialText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeIn(tutorialText[0]));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject.CompareTag("Player"))
        {
            HandleCollision();
        }
    }

    private void HandleCollision()
    {
        collidedCount++;
        if (collidedCount == 1)
        {
            StartCoroutine(FadeIn(tutorialText[1]));
        }
        else if (collidedCount == 4)
        {
            StartCoroutine(FadeIn(tutorialText[2]));
        }
    }

    IEnumerator FadeIn(TextMeshProUGUI text)
    {
        if (text == tutorialText[0]) yield return new WaitForSeconds(1.5f);

        text.DOFade(1, 0.75f).Play();
    }
}
