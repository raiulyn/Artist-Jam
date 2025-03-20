using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    Image background;
    bool faded = true;

    public static EffectManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background = GameObject.Find("Background").GetComponent<Image>();
    }

    public IEnumerator Fade()
    {
        if (faded)
        {
            background.DOFade(1, .25f).Play();
            faded = false;
        }
        else
        {
            background.DOFade(0, .25f).Play();
            faded = true;
        }

        yield return new WaitForSeconds(.25f);
    }
}
