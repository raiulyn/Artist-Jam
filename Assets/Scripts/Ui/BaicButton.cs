using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BaicButton : MonoBehaviour
{
    public Button myButton;
    public string sceneToLoad;

    void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManagerr.Instance.LoadScene(sceneToLoad);
        }
    }

    private void OnMouseEnter()
    {
        transform.DOScale(1.1f, 0.2f).Play();
    }

    private void OnMouseExit()
    {
        transform.DOScale(1f, 0.2f).Play();
    }
}
